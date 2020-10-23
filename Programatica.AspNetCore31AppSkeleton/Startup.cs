using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Programatica.AspNetCore31AppSkeleton.Adapters;
using Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.Handlers;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Context;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using Programatica.Framework.Services.Handlers;
using Programatica.Framework.Services.Injector;

namespace Programatica.AspNetCore31AppSkeleton
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logoff";
                    });

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            // sqlserver context
            // uncomment this to use sql server
            services.AddDbContext<IDbContext, AppDbContext>(opt =>
                            {
                                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                            }, ServiceLifetime.Transient);

            // inmemory context
            // comment this to use sql server
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
            //services.AddDbContext<IDbContext, AppDbContext>(opt => opt.UseInMemoryDatabase(builder.InitialCatalog), ServiceLifetime.Transient);

            // repository
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            // adapters
            services.AddTransient<IDateTimeAdapter, DateTimeAdapter>();
            services.AddTransient<IAuthUserAdapter, ClaimBasedAuthAdapter>();
            services.AddTransient<IJsonSerializerAdapter, JsonSerializerAdapter>();
            services.AddTransient<IPageAdapter, PageAdapter>();

            // event handler
            services.AddTransient<IEventHandler<Dummy>, AuditEventHandler<Dummy>>();
            services.AddTransient<IEventHandler<Dummy>, ServiceEventHandler<Dummy>>();
            services.AddTransient<IEventHandler<User>, AuditEventHandler<User>>();
            services.AddTransient<IEventHandler<User>, ServiceEventHandler<User>>();
            services.AddTransient<IEventHandler<Role>, AuditEventHandler<Role>>();
            services.AddTransient<IEventHandler<Role>, ServiceEventHandler<Role>>();
            services.AddTransient<IList<IEventHandler<Dummy>>>(p => p.GetServices<IEventHandler<Dummy>>().ToList());
            services.AddTransient<IList<IEventHandler<User>>>(p => p.GetServices<IEventHandler<User>>().ToList());
            services.AddTransient<IList<IEventHandler<Role>>>(p => p.GetServices<IEventHandler<Role>>().ToList());
            services.AddTransient<IList<IEventHandler<TrackChange>>>(p => p.GetServices<IEventHandler<TrackChange>>().ToList());

            // injector
            services.AddTransient(typeof(IInjector<>), typeof(Injector<>));

            // service
            services.AddTransient(typeof(IService<>), typeof(Service<>));
            services.AddTransient<Services.IAuthenticationService, Services.AuthenticationService>();

            // others
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
