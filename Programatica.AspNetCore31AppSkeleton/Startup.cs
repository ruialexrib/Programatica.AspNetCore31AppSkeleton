using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context;
using Programatica.AspNetCore31AppSkeleton.Extensions;
using Programatica.Framework.Data.Context;

namespace Programatica.AspNetCore31AppSkeleton
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddCustomAuthentication();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });


            // sqlserver context
            // uncomment this to use sql server
            services.AddDbContext<IDbContext, AppDbContext>(opt =>
                { opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); }, ServiceLifetime.Scoped);

            // inmemory context
            // comment this to use sql server
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
            //services.AddDbContext<IDbContext, AppDbContext>(opt => opt.UseInMemoryDatabase(builder.InitialCatalog), ServiceLifetime.Transient);

            // Infrastructure Services
            services.AddInfrastructureServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Configuring...");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. 
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
