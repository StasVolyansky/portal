﻿using Microsoft.EntityFrameworkCore;
using Portal.Domain.System.Entities;

namespace Portal.Data.System
{
    public class SystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleEnrolment> RoleEnrolments { get; set; }

        public SystemContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("system");

            modelBuilder.Entity<RoleEnrolment>()
                .HasOne(enrollment => enrollment.Role);
        }
    }
}