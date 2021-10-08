using System;
using Autofac;
using Castle.Core.Configuration;
using Gocent.Abp.Application;
using Gocent.Abp.Application.Shared;
using Gocent.Abp.Authorization;
using Gocent.Abp.Authorization.IToken;
using Gocent.Abp.Authorization.Token;
using Gocent.Abp.Redis;
using Gocent.Abp.Web.Fliters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Gocent.Abp.Web.Api
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(GocentAbpDddApplicationModule),
        typeof(GocentAbpWebFilterModule),
        typeof(GocentAbpAuthorizationModule),
        typeof(GocentAbpRedisModule)
    )]
    public class GocentWebModules : AbpModule
    {
        private readonly IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="context"></param>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            //services.AddControllersWithViews((opt) =>
            //{
            //     //添加过滤器等

            // }).AddNewtonsoftJson();
            //services.AddScoped<IDESService, DESService>(opt => new(configuration));
            //services.AddScoped<IMd5Service, Md5Service>();
            //services.AddScoped<ITokenService, TokenService>(opt => new(new Md5Service(), new DESService(configuration)));
            //跨域
            services.AddCors(Options =>
            {
                Options.AddPolicy("cors", Opt =>
                {
                    Opt.AllowAnyHeader();
                    Opt.AllowAnyMethod();
                    Opt.AllowAnyOrigin();
                    Opt.AllowCredentials();

                });

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gocent.Abp.Web.Api", Version = "v1" });
            });
            base.ConfigureServices(context);
        }
        /// <summary>
        /// 加载服务配置
        /// </summary>
        /// <param name="context"></param>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //配置swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gocent.Abp.Web.Api v1"));
             

            app.UseRouting();

            app.UseAuthorization();
            // app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            base.OnApplicationInitialization(context);
        }
    }
}
