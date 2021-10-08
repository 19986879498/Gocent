using Gocent.Abp.Redis.RedisFactory;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Redis
{
    [DependsOn(
        typeof(AbpCachingStackExchangeRedisModule)
        )]
    public class GocentAbpRedisModule:AbpModule
    {
        
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            IConfigurationRoot root = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            context.Services.AddStackExchangeRedisCache(delegate (RedisCacheOptions options)
            {
                string text2 = root["Redis:Configuration"];
                if (!text2.IsNullOrEmpty())
                {
                    options.Configuration = text2;
                }
            });

            services.AddSingleton<IDistributedCache, AbpRedisCache>(opt => new AbpRedisCache(new RedisCacheOptions() { Configuration = root["Redis:Configuration"] }));

            base.ConfigureServices(context);
        }
        
    }
}
