using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMSMinimalApiApp.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; init; }
        public DbSet<BookIssued> BookIssued { get; init; }

        public DbSet<Users> Users { get; init; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type t = typeof(AppDbContext);
            modelBuilder.ApplyConfigurationsFromAssembly(t.Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
