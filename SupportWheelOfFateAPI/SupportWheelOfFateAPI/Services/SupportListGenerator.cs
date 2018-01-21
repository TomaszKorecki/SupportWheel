using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SupportWheelOfFateInfrastructure.Extensions;
using SupportWheelOfFateInfrastructure.Interfaces;
using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateAPI.Services
{
    public class SupportListGenerator : ISupportListGenerator
    {
        public SupportList GeneratePlan(List<Employee> employees, int daysPeriod)
        {
            var workDays = DateTime.Now.GetNextWorkingDays(daysPeriod).ToList();
            Random random = new Random();
            List<SupportDay> supportDays = new List<SupportDay>();

            var firstEmployee = employees.GetRandomEmployee(random);
            var employeesQueryable = employees.AsQueryable();

            SupportDay supportDay = new SupportDay()
            {
                Date = workDays[0],
                ShiftOne = firstEmployee,
                ShiftTwo = employeesQueryable.GetRandomEmployee(exceptEmployee: firstEmployee, random: random)
            };

            supportDays.Add(supportDay);

            for (int i = 1; i < workDays.Count; i++)
            {
                var availableEmployees = employeesQueryable.GetEmployeesWhoDidNotSupportOnDay(supportDays.Last());

                Employee shiftOne = availableEmployees.GetRandomEmployee(random);
                Employee shiftTwo = availableEmployees.GetRandomEmployee(exceptEmployee: shiftOne, random: random);

                supportDays.Add(new SupportDay()
                {
                    Date = workDays[i],
                    ShiftOne = shiftOne,
                    ShiftTwo = shiftTwo
                });
            }

            return new SupportList(supportDays);
        }

        //public bool ValidateSupportDaysList(List<SupportDay> supportDays)
        //{
        //    var previousSupportDay = supportDays.First();

        //    for (int i = 1; i < supportDays.Count; i++)
        //    {
        //        var supportDay = supportDays[i];
        //        if (supportDay.ShiftOne.Id == supportDay.ShiftTwo.Id)
        //        {
        //            return false;
        //        }

        //        if (previousSupportDay.ShiftOne.Id == supportDay.ShiftOne.Id
        //            || previousSupportDay.ShiftOne.Id == supportDay.ShiftTwo.Id
        //            || previousSupportDay.ShiftTwo.Id == supportDay.ShiftOne.Id
        //            || previousSupportDay.ShiftTwo.Id == supportDay.ShiftTwo.Id)
        //        {
        //            return false;
        //        }

        //        previousSupportDay = supportDay;
        //    }

        //    return true;
        //}
    }
}
