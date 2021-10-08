using System;
using System.Collections.Generic; 
using Gocent.Abp.Application.Contracts.ICommonService;
using Gocent.Abp.Web.Fliters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gocent.Abp.Web.Api.Controllers
{
    [TypeFilter(typeof(GocentExceptionFilterAttribute))]
    [ServiceFilter(typeof(GocentExceptionFilterAttribute))]
     [ApiController]
    [Route("/api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _Testservice;

        public TestController(ITestService testService)
        {
            this._Testservice=testService;
        }
        [HttpGet,Route("GetStrings")]
        public List<string> GetStrings()
        {
            return this._Testservice.GetStrings();
        }

        [HttpGet,Route("ExceptTest")]
        public IActionResult ExceptTest()
        {
            int i=5;
            int j=0;
            var expt=i/j;
            return Ok("ok");
        }
    }
}
