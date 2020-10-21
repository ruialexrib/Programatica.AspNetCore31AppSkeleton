﻿using Microsoft.EntityFrameworkCore;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Data.Context;
using System;

//https://snede.net/you-dont-need-a-idesigntimedbcontextfactory/

namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context
{
    public class AppDbContext : BaseDbContext
    {
        public DbSet<Dummy> Dummies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(ur => ur.RoleId);

            // seed users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    IsSystem = true
                }
            );

            // seed roles
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrators",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    IsSystem = true
                }
            );

            // seed data
            modelBuilder.Entity<Dummy>().HasData(
                new Dummy
                {
                    Id = 1,
                    Description = "Dummy One",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system"
                },
                new Dummy
                {
                    Id = 2,
                    Description = "Dummy Two",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system"
                }
            );
        }
    }
}
