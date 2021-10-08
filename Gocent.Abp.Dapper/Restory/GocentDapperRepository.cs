using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace Gocent.Abp.Dapper.Restory
{
   public class GocentDapperRepository: DapperRepository<GocentDapperDbContext>,ITransientDependency
    {
        public GocentDapperRepository(IDbContextProvider<GocentDapperDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
            
        }

    }
}
