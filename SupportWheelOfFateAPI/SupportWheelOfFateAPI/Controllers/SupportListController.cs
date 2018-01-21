using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SupportWheelOfFateAPI.Models.Configuration;
using SupportWheelOfFateAPI.Services;
using SupportWheelOfFateInfrastructure.Interfaces;

namespace SupportWheelOfFateAPI.Controllers
{   
    [Produces("application/json")]
    [Route("api/SupportList")]
    public class SupportListController : Controller
    {
        ISupportListGenerator SupportListGenerator { get; }
        IEmployeeRepository EmployeeRepository{ get; }
        private SupportWheelConfiguration SupportWheelConfiguration { get; }

        public SupportListController(
            ISupportListGenerator supportListGenerator,
            IEmployeeRepository employeeRepository,
            ISupportListRepository supportListRepository,
            IOptions<SupportWheelConfiguration> supportWheelOptions)
        {
            SupportListGenerator = supportListGenerator;
            EmployeeRepository = employeeRepository;
            SupportWheelConfiguration = supportWheelOptions.Value;
        }


        [HttpGet]
        public dynamic Get()
        {
            var supportPlan = SupportListGenerator.GeneratePlan(EmployeeRepository.GetEmployees(), SupportWheelConfiguration.SupportWindowPeriod);
            var validate = SupportListGenerator.ValidateSupportDaysList(supportPlan);

            return validate ? supportPlan : null;
        }

        [HttpPost("regenerate")]
        public dynamic RegenerateList()
        {
            return null;
        }
    }
}