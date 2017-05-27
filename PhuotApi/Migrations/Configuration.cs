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
            AutomaticMigrationsEnabled = true;
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
                    Id = new Guid("D97D135E-9ACF-4B87-A40A-9DEBE92A9C17"),
                    FirstName = "Vu",
                    LastName = "Nguyen"
                },
                new UserProfile()
                {
                    Id = new Guid("5905DCD7-5134-4A5F-8B78-A77CD29A6D28"),
                    FirstName = "Edmund",
                    LastName = "Nguyen"
                },
                new UserProfile()
                {
                    Id = new Guid("2654EB30-FA99-40D9-AB60-5067C3A21F2E"),
                    FirstName = "Minh",
                    LastName = "Nguyen"
                });
            context.SaveChanges();

            context.PlaceTypes.AddOrUpdate(x => x.TypeId,
                new PlaceType()
                {
                    TypeId = 1,
                    TypeName = "Bus"
                },
                new PlaceType()
                {
                    TypeId = 2,
                    TypeName = "Gas Station"
                },
                new PlaceType()
                {
                    TypeId = 3,
                    TypeName = "Restaurant"
                });
            context.SaveChanges();

            context.Places.AddOrUpdate(x => x.PlaceId,
                new Place()
                {
                    PlaceId = 1,
                    PlaceName = "Papa's House",
                    TypeId = 1
                },
                new Place()
                {
                    PlaceId = 2,
                    PlaceName = "Houston Downtown",
                    TypeId = 2
                },
                new Place()
                {
                    PlaceId = 3,
                    PlaceName = "Cades Ct",
                    TypeId = 3
                });
            context.SaveChanges();

            context.NonnativePlaces.AddOrUpdate(x => x.NonnativePlaceId,
                new NonnativePlace()
                {
                    NonnativePlaceId = 1,
                    PlaceId = 1,
                    NonnativePlaceName = "Test House"
                },
                new NonnativePlace()
                {
                    NonnativePlaceId = 2,
                    PlaceId = 1,
                    NonnativePlaceName = "Test 2"
                },
                new NonnativePlace()
                {
                    NonnativePlaceId = 3,
                    PlaceId = 3,
                    NonnativePlaceName = "Street"
                });
            context.SaveChanges();

        }
    }
}
