using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Application.Shared
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
    )]
    public class GocentAbpDddApplicationContractsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
