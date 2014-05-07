using PredicateBuilder.Entities;
using PredicateBuilder.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateBuilder
{
    public class SimpleContext : DbContext
    {
        public SimpleContext() :
            base("simpleConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleContext, SimpleContextMigrationConfiguration>());
        }
        public DbSet<Student> Students { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMapper());                                    

            base.OnModelCreating(modelBuilder);
        }
    }

    class SimpleContextMigrationConfiguration : DbMigrationsConfiguration<SimpleContext>
    {
        public SimpleContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

#if DEBUG
        protected override void Seed(SimpleContext context)
        {
            new SimpleDataSeeder(context).Seed();
        }
#endif

    }
}
