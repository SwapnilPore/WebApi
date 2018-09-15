using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Contracts.Interfaces;

namespace WebApi.Controllers
{
    //[Route("api/employee/")]
    public class EmployeeController : ApiController
    {
        
        private readonly IAppService _appService;

        public EmployeeController(IAppService appService)
        {
            _appService = appService;
        }

        [Route("api/employee/getemp/{name}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeDataByName([FromUri]string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check the Parameters");
            }

            var employeeData = _appService.GetPagedEmployeeDataByName(name);

            if(!employeeData.Any())
            {
                return NotFound();
            }

            return Ok(employeeData);
        }

    }
}
