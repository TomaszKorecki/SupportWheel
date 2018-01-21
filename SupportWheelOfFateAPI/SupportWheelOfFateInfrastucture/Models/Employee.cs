using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SupportWheelOfFateInfrastructure.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class EmployeeExtensions
    {
        public static Employee GetRandomEmployee(this List<Employee> employees, Random random)
        {
            return employees[random.Next(employees.Count)];
        }

        public static Employee GetRandomEmployee(this IQueryable<Employee> employees, Random random)
        {
            return employees.ToList().GetRandomEmployee(random);
        }

        public static Employee GetRandomEmployee(this IQueryable<Employee> employees, Employee exceptEmployee, Random random)
        {
            return employees.Except(new List<Employee>() { exceptEmployee }).ToList().GetRandomEmployee(random);
        }

        public static IQueryable<Employee> GetEmployeesWhoDidNotSupportOnDay(this IQueryable<Employee> employees,
            SupportDay supportDay)
        {
            if (supportDay != null)
            {
                return employees.Where(employee => employee != supportDay.ShiftOne && employee != supportDay.ShiftTwo);

            }

            return employees;
        }

        public static IQueryable<Employee> GetEmployeesWhoSupportedLess(this IQueryable<Employee> employees,
            List<SupportDay> supportDays)
        {
            var employeeOccupancy = GetEmployeeOccupancy(employees, supportDays);
            var occupancies = employeeOccupancy.Values.Distinct();

            if (occupancies.Count() > 1)
            {
                var maxOccupancy = employeeOccupancy.Values.Max();
                return employees.Where(e => employeeOccupancy[e] < maxOccupancy);
            }

            return employees;
        }

        private static Dictionary<Employee, int> GetEmployeeOccupancy(IQueryable<Employee> employees, List<SupportDay> supportDays)
        {
            var employeeOccupancy = employees.ToDictionary(e => e, e => 0);

            supportDays.ForEach(supportDay =>
            {
                employeeOccupancy[supportDay.ShiftOne]++;
                employeeOccupancy[supportDay.ShiftTwo]++;
            });

            return employeeOccupancy;
        }
    }
}
