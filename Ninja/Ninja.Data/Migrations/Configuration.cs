namespace Ninja.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NinjaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NinjaContext context)
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

            context.Clans.AddOrUpdate(p => p.Name,
                new Ninja.Domain.Clan { Name = "Clan HC" },
                new Ninja.Domain.Clan { Name = "Clan HŽ" });

            context.Ninjas.AddOrUpdate(p => p.Name,
                new Ninja.Domain.Ninja { Name = "JosipSan", Password = "pass" },
                new Ninja.Domain.Ninja { Name = "MiroSan", Password = "pass" });
                

        }
    }
}
