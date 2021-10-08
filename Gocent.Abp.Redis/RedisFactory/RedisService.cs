using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;

namespace Gocent.Abp.Redis.RedisFactory
{
    public class RedisService
    {
        private readonly IDistributedCache cacheService;

        public  RedisService(IDistributedCache cacheService)
        {
            this.cacheService = cacheService;
        }

        public   int Set(string key,object value)
        {
            try
            {
                string seralizeStr = JsonConvert.SerializeObject(value);
                byte[] bytevalue = Encoding.UTF8.GetBytes(seralizeStr);
                cacheService.Set(key, bytevalue);
                return 1;
            }
            catch 
            {
                return -1;
            }

        }
    }
}
