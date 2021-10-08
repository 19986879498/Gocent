using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Dapper
{
    [DependsOn(
        typeof(AbpDapperModule)
        )]
    public class GocentAbpDapperModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            ///注入sqlserver数据库
            services.AddDbContext<GocentDapperDbContext>();
            Configure<AbpDbContextOptions>(Options => {
                Options.UseSqlServer();
            });
            base.ConfigureServices(context);
        }
    }
}
