using SupportWheelOfFateInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportWheelOfFateInfrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}
