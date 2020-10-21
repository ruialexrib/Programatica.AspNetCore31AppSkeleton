using Microsoft.AspNetCore.Http;
using Programatica.Framework.Core.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public class ClaimBasedAuthAdapter : IAuthUserAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Name
        {
            get
            {
                return _httpContextAccessor.HttpContext.User.Identity.Name;
            }
        }
        public string Password { get; }
        public string AuthenticationType
        {
            get
            {
                return _httpContextAccessor.HttpContext.User.Identity.AuthenticationType;
            }
        }
        public DateTime LastLoginDateTime { get; }

        public ClaimBasedAuthAdapter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
