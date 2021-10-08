using System;
using Gocent.Abp.Web.Fliters.Filters;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Web.Fliters
{
    [DependsOn(

    )]
    public class GocentAbpWebFilterModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddSingleton<GocentExceptionFilterAttribute>();
            services.AddControllersWithViews((opt) =>
          {
                //添加过滤器等
                opt.Filters.Add<GocentExceptionFilterAttribute>();

            }).AddNewtonsoftJson();
            base.ConfigureServices(context);
        }
    }
}
