using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Models;
using System;
using System.Data.Entity;

namespace Swu.Portal.Data.Context
{
    public class SwuDBContext : DbContext, IDisposable
    {
        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<IdentityUserLogin> UserLogin { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
        //public DbSet<IdentityUserRole> UserRole { get; set; }

        public SwuDBContext():base("DefaultConnection")
        {

        }
        public SwuDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(l => l.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
