using Microsoft.EntityFrameworkCore;
using Portal.Domain.System;

namespace Data.System
{
    public class SystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SystemContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("system");
        }
    }
}