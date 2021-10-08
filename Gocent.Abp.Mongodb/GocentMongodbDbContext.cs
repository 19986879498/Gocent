using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Gocent.Abp.Mongodb
{
    [ConnectionStringName("Default")]
  public  class GocentMongodbDbContext:AbpMongoDbContext
    {
        //[MongoCollection("MyQuestions")] //映射MongoDB的表名
        //public IMongoCollection<Question> Questions => Collection<Question>();

        //public IMongoCollection<Category> Categories => Collection<Category>();
        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
            /*
             *  modelBuilder.Entity<Question>(b =>
                 {
                    b.CollectionName = "MyQuestions"; //Sets the collection name
                     b.BsonMap.UnmapProperty(x => x.MyProperty); //Ignores 'MyProperty'
                  });
             */
        }
    }
}
