namespace OCCSolution.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OCCSolution.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<OCCSolution.Models.OCCEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        /// <summary> Seed Method
        /// This seed() method in configuration.cs is called when you run update-database in the Package Manager Console (PMC).
        /// It's also called at application startup if you change Entity Framework to use the MigrateDatabaseToLatestVersion database initializer.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(OCCSolution.Models.OCCEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
