using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;

namespace Gocent.Abp.Mongodb
{
    [DependsOn(
        typeof(AbpMongoDbModule)
        )]
    public class GocentAbpMongodbModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddMongoDbContext<GocentMongodbDbContext>(opt=> {
                opt.AddDefaultRepositories();
            });
            /*
             MongoDB 从 4.0 版本开始支持多文档事务，ABP 框架也支持。但是，启动模板 默认禁用事务。如果您的 MongoDB服务器支持事务，您可以在YourProjectMongoDbModule类中启用它：
             */
            //Configure<AbpUnitOfWorkDefaultOptions>(options =>
            //{
            //    options.TransactionBehavior = UnitOfWorkTransactionBehavior.Auto;
            //});
            base.ConfigureServices(context);
        }
    }
}
