using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Data;

namespace Gocent.Abp.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class GocentDBContext:AbpDbContext<GocentDBContext>
    {
        public GocentDBContext(DbContextOptions<GocentDBContext> dbContext):base(dbContext)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
