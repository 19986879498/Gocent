using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gocent.Abp.Web.Fliters.Filters
{
    
    public class GocentExceptionFilterAttribute:ExceptionFilterAttribute
    {
        /// <summary>
        /// 捕捉异常的过滤器
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result=new JsonResult(new {code=500,Exception=context.Exception.Message,Context=context.Exception.StackTrace});
                System.Console.WriteLine("出现了异常，异常信息："+context.Exception.Message);
                context.ExceptionHandled=true;
            }
            base.OnException(context);
        }
    }
}
