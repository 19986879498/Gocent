using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Gocent.Abp.Dapper
{
    [ConnectionStringName("Default")]
  public  class GocentDapperDbContext:AbpDbContext<GocentDapperDbContext>
    {
        public GocentDapperDbContext(DbContextOptions<GocentDapperDbContext> dbContext):base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
