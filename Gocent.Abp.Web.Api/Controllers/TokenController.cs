using Gocent.Abp.Authorization.IToken;
using Gocent.Abp.Web.Fliters.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gocent.Abp.Web.Api.Controllers
{
    [TypeFilter(typeof(GocentExceptionFilterAttribute))]
    [ServiceFilter(typeof(GocentExceptionFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="UserId">用户名</param>
        /// <returns></returns>
        [HttpGet,Route("GetToken")]
        public JsonResult GetToken(string UserId)
        {
            string token = this.tokenService.CreateToken(userId: UserId, 1);
            dynamic returnobj = new { code=200,accessToken=token,Msg="token获取成功，有效时间为1分钟"};
            return new JsonResult(returnobj);

        }
        [HttpGet,Route("ValidToken")]
        public JsonResult ValidToken(string TokenStr)
        {
            (string UserId, bool isExp) = this.tokenService.DecryptToken(TokenStr);
            dynamic dydata = new { };
            if (isExp)
            {
                dydata = new { code = 415, UserId = UserId, isexp = isExp, Msg = "token已过期请重新获取token" };
            }
            else
            {
                dydata = new { code = 200, isExp, Msg = "token验证成功！" };
            }
            return new JsonResult(dydata);
        }
    }
}
