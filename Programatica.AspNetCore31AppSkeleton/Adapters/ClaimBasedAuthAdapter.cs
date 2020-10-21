using Microsoft.AspNetCore.Http;
using Programatica.Framework.Core.Adapter;
using System;
using System.Linq;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public class ClaimBasedAuthAdapter : IAuthUserAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string Name
        {
            get
            {
                return _httpContextAccessor.HttpContext.User
                                .Claims
                                .FirstOrDefault(x => x.Type.Equals("AuthenticatedUserName"))
                                .Value;
            }
        }
        public string Password
        {
            get
            {
                return _httpContextAccessor.HttpContext.User
                                .Claims
                                .FirstOrDefault(x => x.Type.Equals("AuthenticatedUserPassword"))
                                .Value;
            }
        }
        public string AuthenticationType
        {
            get
            {
                return _httpContextAccessor.HttpContext.User.Identity.AuthenticationType;
            }
        }
        public DateTime LastLoginDateTime
        {
            get
            {
                return DateTime.Parse(
                    _httpContextAccessor.HttpContext.User
                                            .Claims
                                            .FirstOrDefault(x => x.Type.Equals("AuthenticatedUserLastLoginDateTime"))
                                            .Value
                    );
            }
        }

        public ClaimBasedAuthAdapter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
