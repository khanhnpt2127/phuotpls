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

        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountStatus> UserAccountStatuses { get; set; }
        public DbSet<UserPictureProfile> UserPictureProfiles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Follower> Followers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}