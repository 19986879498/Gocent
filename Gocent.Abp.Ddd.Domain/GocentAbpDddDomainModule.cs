using System;
using Volo.Abp.Modularity;

namespace Gocent.Abp.Ddd.Domain
{
    [DependsOn(
        
    )]
    public class GocentAbpDddDomainModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
