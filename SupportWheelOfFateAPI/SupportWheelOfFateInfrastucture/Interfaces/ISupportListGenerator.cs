using System;
using System.Collections.Generic;
using System.Text;

using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateInfrastructure.Interfaces
{
    public interface ISupportListGenerator
    {
        SupportList GeneratePlan(List<Employee> employees, int daysPeriod);
        //bool ValidateSupportDaysList(List<SupportDay> supportDays);
    }
}
