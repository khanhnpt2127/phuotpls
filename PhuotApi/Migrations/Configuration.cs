using PhuotApi.Models;

namespace PhuotApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhuotApi.Models.PhuotApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhuotApi.Models.PhuotApiContext context)
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
            context.UserAccountStatuses.AddOrUpdate(x => x.StatusId,

                new UserAccountStatus()

                {

                    StatusId = 1,

                    Status = "CONFIRMED"

                },

                new UserAccountStatus()

                {

                    StatusId = 2,

                    Status = "NON_CONFIRMED"

                });
            context.SaveChanges();
            context.UserProfiles.AddOrUpdate(x => x.Id,

                new UserProfile()

                {

                    Id = 1,

                    FirstName = "Vu",

                    LastName = "Nguyen"

                },

                new UserProfile()

                {

                    Id = 2,

                    FirstName = "Edmund",

                    LastName = "Nguyen"

                },

                new UserProfile()

                {

                    Id = 3,

                    FirstName = "Minh",

                    LastName = "Nguyen"

                });
            context.SaveChanges();
        }
    }
}
