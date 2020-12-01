using Microsoft.EntityFrameworkCore;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Data.Context;
using System;
using System.Linq;

//https://snede.net/you-dont-need-a-idesigntimedbcontextfactory/

namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context
{
    public class AppDbContext : BaseDbContext
    {
        public DbSet<Dummy> Dummies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "pass",
                    Email="admin@server.com",
                    Fullname="System Administrator",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
                    IsSystem = true
                },
                new User
                {
                    Id = 2,
                    Username = "user",
                    Password = "pass",
                    Email = "user@server.com",
                    Fullname = "Just an User",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
                    IsSystem = false
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
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
                    IsSystem = true
                },
                new Role
                {
                    Id = 2,
                    Name = "Users",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
                    IsSystem = true
                }
            );

            // seed permissions
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1,
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
                    IsSystem = true
                },
                new UserRole
                {
                    Id = 2,
                    UserId = 1,
                    RoleId = 2,
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
                    IsSystem = true
                },
                new UserRole
                {
                    Id = 3,
                    UserId = 2,
                    RoleId = 2,
                    CreatedDate = DateTime.UtcNow,
                    CreatedUser = "system",
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedUser = "system",
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

            // disable ManyToMany Cascade Delete
            var fks = modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in fks)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
