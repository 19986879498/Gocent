using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IDistributedCache cachaService;

        public RedisController(IDistributedCache cachaService)
        {
            this.cachaService = cachaService;
        }
        [HttpGet, Route("redisSave")]
        public IActionResult redisSave()
        {
            Dictionary<string, string> dicredis = new Dictionary<string, string>();
            dicredis.Add("1001", "张三");
            dicredis.Add("1002","李四");
            dicredis.Add("1003","王五");
            dicredis.Add("1004","赵六");
            dicredis.Add("1005","孙琪");
            dicredis.Add("1006", "田吧");

            foreach (var item in dicredis)
            {
                this.cachaService.SetStringAsync(item.Key, item.Value).Wait();
            }
            List<string> strlist = new List<string>();

            foreach (var item in dicredis)
            {
                strlist.Add($"获取redis数据的key为{item.Key},获取redis 的值为："+this.cachaService.GetStringAsync(item.Key).Result);
            }

            return new JsonResult(new { code = 200, type = "redis", data = strlist, msg = "获取成功！" });
        }

        [HttpGet,Route("GetRedisAll")]
        public IActionResult GetRedisAll()
        {
            dynamic dy = new { name = "张三", sex = "男", age = 80, work = ".NetCore高级开发工程师", remark = string.Empty };
            byte[] dystrbyte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dy));
            this.cachaService.SetAsync("1001",dystrbyte, new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow=TimeSpan.FromSeconds(60),AbsoluteExpiration= DateTimeOffset.Now.AddMinutes(1),SlidingExpiration=TimeSpan.FromSeconds(50)}).Wait();
            var res = this.cachaService.GetAsync("1001").Result;
            var str = Encoding.UTF8.GetString(res);
            return new JsonResult(new {code=200,data=str,msg="获取成功！" });
        }
    }
}
