using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Migrations;
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
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumCategory> ForumCategory { get; set; }
        public DbSet<Research> Research { get; set; }
        public DbSet<ResearchCategory> ResearchCategory { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<TeacherProfile> TeacherProfile { get; set; }
        //public DbSet<Contact> Contact { get; set; }
        //public DbSet<StudentProfile> StudentProfile { get; set; }
        //public DbSet<ParentProfile> ParentProfile { get; set; }
        public SwuDBContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new DatabaseInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }
        public SwuDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer(new DatabaseInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(i => i.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.RoleId, i.UserId });

            modelBuilder.Entity<Course>();
            modelBuilder.Entity<CourseCategory>();
            modelBuilder.Entity<Curriculum>();
            modelBuilder
                .Entity<ApplicationUser>()
                .HasMany<Course>(c => c.StudentCourses)
                .WithMany(s => s.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentRefId");
                    cs.MapRightKey("CourseRefId");
                    cs.ToTable("StudentCourse");
                });
            modelBuilder
                .Entity<ApplicationUser>()
                .HasMany<Course>(c => c.TeacherCourses)
                .WithMany(t => t.Teachers)
                .Map(ct =>
                {
                    ct.MapLeftKey("TeacherRefId");
                    ct.MapRightKey("CourseRefId");
                    ct.ToTable("TeacherCourse");
                });
            modelBuilder.Entity<Forum>();
            modelBuilder.Entity<ForumCategory>();
            modelBuilder.Entity<Comment>();
            //modelBuilder.Entity<TeacherProfile>();
            //modelBuilder.Entity<Contact>();
            //modelBuilder.Entity<StudentProfile>();
            //modelBuilder.Entity<ParentProfile>();
        }
    }
}
