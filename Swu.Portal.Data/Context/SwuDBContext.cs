using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Swu.Portal.Data.Context
{
    public class SwuDBContext : DbContext, IDisposable
    {
        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<IdentityUserLogin> UserLogin { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
        //public DbSet<IdentityUserRole> UserRole { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategory {get;set;}
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
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(i => i.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.RoleId, i.UserId });

            modelBuilder.Entity<Course>();
            modelBuilder.Entity<CourseCategory>();

        }
    }
}
