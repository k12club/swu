using Microsoft.AspNet.Identity.EntityFramework;
using Swu.Portal.Data.Migrations;
using Swu.Portal.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Swu.Portal.Data.Context
{
    public class SwuDBContext : DbContext, IDisposable
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumCategory> ForumCategory { get; set; }
        public DbSet<Research> Research { get; set; }
        public DbSet<ResearchCategory> ResearchCategory { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<StudentScore> StudentScore { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<AttachFile> AttachFiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<ReferenceUser> ReferenceUser { get; set;}
        public DbSet<PersonalFile> PersonalFiles { get; set; }
        public DbSet<CurriculumDocument> CurriculumDocuments { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public SwuDBContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
        public SwuDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(i => i.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(i => i.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.RoleId, i.UserId });
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
            modelBuilder.Entity<Course>();
        }
    }
}
