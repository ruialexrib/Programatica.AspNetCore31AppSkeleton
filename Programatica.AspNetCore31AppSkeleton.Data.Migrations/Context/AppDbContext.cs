using Microsoft.EntityFrameworkCore;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.Framework.Data.Context;

//https://snede.net/you-dont-need-a-idesigntimedbcontextfactory/

namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context
{
    public class AppDbContext : BaseDbContext
    {
        public DbSet<Dummy> Dummies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data
            modelBuilder.Entity<Dummy>().HasData(
                new Dummy
                {
                    Id = 1,
                    Description = "Dummy One" 
                },
                new Dummy
                {
                    Id = 2,
                    Description = "Dummy Two"
                }
            );
        }
    }
}
