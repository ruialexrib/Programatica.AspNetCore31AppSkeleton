using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .AddUserSecrets(Assembly.GetExecutingAssembly())
               .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            
            // sql server
            // var connectionString = configuration.GetConnectionString("DefaultConnection");
            // builder.UseSqlServer(connectionString);

            // mysql
            // Debugger.Launch();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseMySql(connectionString,
                             opt => opt.ServerVersion(new System.Version(5, 5, 60), ServerType.MySql)
                             );

            return new AppDbContext(builder.Options);
        }
    }
}
