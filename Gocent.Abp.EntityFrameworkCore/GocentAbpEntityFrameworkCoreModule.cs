using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Gocent.Abp.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class GocentAbpEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            ///注入sqlserver数据库
            services.AddDbContext<GocentDBContext>(opt =>
            {
                // opt.AddDefaultRepositories();//添加工厂
            });
            //SqlServer
            Configure<AbpDbContextOptions>(Options =>
            {
                Options.UseSqlServer();
            });
            //Mysql 
            //            Configure<AbpDbContextOptions>(options =>
            //{
            //   options.Configure(ctx =>
            //   {
            //       if (ctx.ExistingConnection != null)
            //       {
            //            //UseMySql 此代码中的调用由 Pomelo.EntityFrameworkCore.MySql 包定义，如果需要，您可以使用其附加选项。
            //            ctx.DbContextOptions.UseMySql(ctx.ExistingConnection);
            //       }
            //       else
            //       {
            //           ctx.DbContextOptions.UseMySql(ctx.ConnectionString);
            //       }
            //   });
            //});
            //不同的 DBMS 可能会有一些限制，比如字段名的最大长度、索引长度等，模块可能会提供一些内置的解决方案。您可以通过ModelBuilder. 例如：Identity Server模块
            //builder.ConfigureIdentityServer(options =>
            //{
            //    options.DatabaseProvider = EfCoreDatabaseProvider.MySql;
            //});

            base.ConfigureServices(context);
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {

            base.OnApplicationInitialization(context);
        }
    }
}
