using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Programatica.AspNetCore31AppSkeleton.Adapters;
using Programatica.AspNetCore31AppSkeleton.Data.Models;
using Programatica.AspNetCore31AppSkeleton.Handlers;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Data.Models;
using Programatica.Framework.Data.Repository;
using Programatica.Framework.Services;
using Programatica.Framework.Services.Handlers;
using Programatica.Framework.Services.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceDescriptors(this IServiceCollection services)
        {
            // repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // adapters
            services.AddScoped<IDateTimeAdapter, DateTimeAdapter>();
            services.AddScoped<IAuthUserAdapter, ClaimBasedAuthAdapter>();
            services.AddScoped<IJsonSerializerAdapter, JsonSerializerAdapter>();
            services.AddScoped<IPageAdapter, PageAdapter>();

            // event handler
            services.AddScoped<IEventHandler<Dummy>, AuditEventHandler<Dummy>>();
            services.AddScoped<IEventHandler<Dummy>, ServiceEventHandler<Dummy>>();
            services.AddScoped<IEventHandler<User>, AuditEventHandler<User>>();
            services.AddScoped<IEventHandler<User>, ServiceEventHandler<User>>();
            services.AddScoped<IEventHandler<Role>, AuditEventHandler<Role>>();
            services.AddScoped<IEventHandler<Role>, ServiceEventHandler<Role>>();
            services.AddScoped<IEventHandler<UserRole>, AuditEventHandler<UserRole>>();
            services.AddScoped<IEventHandler<UserRole>, ServiceEventHandler<UserRole>>();
            services.AddScoped<IEventHandler<UserRole>, PermissionEventHandler>();
            services.AddScoped<IList<IEventHandler<Dummy>>>(p => p.GetServices<IEventHandler<Dummy>>().ToList());
            services.AddScoped<IList<IEventHandler<User>>>(p => p.GetServices<IEventHandler<User>>().ToList());
            services.AddScoped<IList<IEventHandler<Role>>>(p => p.GetServices<IEventHandler<Role>>().ToList());
            services.AddScoped<IList<IEventHandler<UserRole>>>(p => p.GetServices<IEventHandler<UserRole>>().ToList());
            services.AddScoped<IList<IEventHandler<TrackChange>>>(p => p.GetServices<IEventHandler<TrackChange>>().ToList());

            // injector
            services.AddScoped(typeof(IInjector<>), typeof(Injector<>));

            // service
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<Services.IAuthenticationService, Services.AuthenticationService>();

            // others
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
