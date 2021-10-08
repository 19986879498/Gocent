using System;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace Gocent.Abp.SignalR
{
    [DependsOn(
        typeof(AbpAspNetCoreSignalRModule)
        )]
    public class GocentAbpSignalRModule:AbpModule
    {
    }
}
