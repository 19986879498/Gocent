using System;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Ddd.Domain.Shared
{
    [DependsOn(
        
    )]
    public class GocentAbpDddDomainSharedModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
