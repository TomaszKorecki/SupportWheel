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
using SupportWheelOfFateInfrastructure.Models;

namespace SupportWheelOfFateAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SupportList")]
    public class SupportListController : Controller
    {
        private ISupportListGenerator SupportListGenerator { get; }
        private ISupportListRepository SupportListRepository { get; }
        private IEmployeeRepository EmployeeRepository { get; }
        private SupportWheelConfiguration SupportWheelConfiguration { get; }

        public SupportListController(
            ISupportListGenerator supportListGenerator,
            IEmployeeRepository employeeRepository,
            ISupportListRepository supportListRepository,
            IOptions<SupportWheelConfiguration> supportWheelOptions)
        {
            SupportListGenerator = supportListGenerator;
            SupportListRepository = supportListRepository;
            EmployeeRepository = employeeRepository;
            SupportWheelConfiguration = supportWheelOptions.Value;
        }

        [HttpGet]
        public List<SupportDay> Get()
        {
            var supportPlan = SupportListRepository.GetSupportList();
            if (supportPlan == null)
            {
                supportPlan = SupportListGenerator.GeneratePlan(
                    EmployeeRepository.GetEmployees(),
                    SupportWheelConfiguration.SupportWindowPeriod);

                SupportListRepository.SaveSupportList(supportPlan);
            }

            return supportPlan.SupportDays;
        }

        [HttpPost("regenerate")]
        public List<SupportDay> RegenerateList()
        {
            var supportPlan = SupportListGenerator.GeneratePlan(
                EmployeeRepository.GetEmployees(),
                SupportWheelConfiguration.SupportWindowPeriod);

            SupportListRepository.SaveSupportList(supportPlan);

            return supportPlan.SupportDays;
        }
    }
}