using Swu.Portal.Data.Models;
using System;
using System.Data.Entity;

namespace Swu.Portal.Data.Context
{
    public class SwuDBContext : DbContext, IDisposable
    {
        public DbSet<PersonalTestData> PersonalTestData { get; set; }

        public SwuDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalTestData>()
                .ToTable("PersonalTestData");

        }
    }
}
