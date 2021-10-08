using System;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Gocent.Abp.Authorization.IToken;
using Gocent.Abp.Authorization.Token;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Application;

namespace Gocent.Abp.Authorization
{
    [DependsOn(
        typeof(AbpDddApplicationModule)
    )]
    public class GocentAbpAuthorizationModule:AbpModule
    {
        private readonly IConfiguration configuration =new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
       
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var Services = context.Services;
            #region 服务的依赖注入

            Services.AddScoped<IDESService, DESService>(opt => new(configuration));
            Services.AddScoped<IMd5Service, Md5Service>();
            Services.AddScoped<ITokenService, TokenService>(opt => new(new Md5Service(), new DESService(configuration)));
            #endregion
            base.ConfigureServices(context);
        }
    }
}
