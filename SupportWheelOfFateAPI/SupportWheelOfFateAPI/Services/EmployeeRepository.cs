using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportWheelOfFateInfrastructure.Interfaces;
using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateAPI.Services
{
    public class EmployeeRepository : IEmployeeRepository

    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee() {Id = 0, Name = "Hooker"},
                new Employee() {Id = 1, Name = "Collier"},
                new Employee() {Id = 2, Name = "Waters"},
                new Employee() {Id = 3, Name = "Walter"},
                new Employee() {Id = 4, Name = "Hendrix"},
                new Employee() {Id = 5, Name = "Simone"},
                new Employee() {Id = 6, Name = "Johnson"},
                new Employee() {Id = 7, Name = "James"},
                new Employee() {Id = 8, Name = "Dixon"},
                new Employee() {Id = 9, Name = "Williamson"},
            };
        }
    }
}
