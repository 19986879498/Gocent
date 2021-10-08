using System;
using Gocent.Abp.Application.CommonService;
using Gocent.Abp.Application.Contracts.ICommonService;
using Gocent.Abp.Application.Shared;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Application
{
    [DependsOn(
         typeof(AbpDddApplicationModule),
        typeof(GocentAbpDddApplicationContractsModule)
       
    )]
    public class GocentAbpDddApplicationModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var  services=context.Services;
            #region 依赖注入服务
            services.AddSingleton<ITestService,TestService>();
            #endregion
            base.ConfigureServices(context);
        }
    }
}
