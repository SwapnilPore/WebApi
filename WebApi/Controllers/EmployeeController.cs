using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Contracts.Interfaces;
using WebApi.Controllers.Filters;

namespace WebApi.Controllers
{
    [Route("api/employee/")]
    public class EmployeeController : ApiController
    {
        
        private readonly IAppService _appService;

        public EmployeeController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeDataByName([FromUri] PagingModel pagingModel, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check the parameters");
            }

            var empData = _appService.GetPagedEmployeeDataByName(name, pagingModel.PageSize, pagingModel.PageNo).ToList();

            if (!empData.Any())
            {
                return NotFound();
            }

            return Ok(empData);
        }

        //[Route("api/Employee/{id:int}")]
        //[HttpGet]
        //public IHttpActionResult GetEmployeeDataById([FromUri] PagingModel pagingModel, int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Please check the parameters");
        //    }

        //    var empData = SkAppservice.GetPagedEmployeeDataById(id, pagingModel.PageSize, pagingModel.PageNo).ToList();

        //    if (!empData.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok(empData);
        //}

    }
}
