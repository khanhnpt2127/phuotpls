using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace PhuotApi.Models
{
    public class PhuotApiContext : DbContext
    {
        public PhuotApiContext() : base("name=PhuotApiContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhuotApiContext, PhuotApi.Migrations.Configuration>("PhuotApiContext"));
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountStatus> UserAccountStatuses { get; set; }
        public DbSet<UserPictureProfile> UserPictureProfiles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<UserPlace> UserPlaces { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public DbSet<NonnativePlace> NonnativePlaces { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripPlace> TripPlaces { get; set; }
        public DbSet<TripStatus> TripStatuses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}