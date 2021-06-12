using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Programatica.Framework.Core.Adapter;
using Programatica.Framework.Mvc.Adapters;
using System.Collections.Generic;
using System.Reflection;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public class PageAdapter : IAppPageAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly HttpContext _httpContext;
        private readonly ITempDataDictionary _tempData;
        private readonly IAppObjectsAdapter _appObjectsAdapter;
        private readonly IAuthUserAdapter _authUserAdapter;

        public PageAdapter(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory,
            IAppObjectsAdapter appObjectsAdapter,
            IAuthUserAdapter authUserAdapter)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _httpContext = _httpContextAccessor.HttpContext;
            _tempData = _tempDataDictionaryFactory.GetTempData(_httpContext);
            _appObjectsAdapter = appObjectsAdapter;
            _authUserAdapter = authUserAdapter;
        }

        public IAppObjectsAdapter AppObjectsAdapter { get { return _appObjectsAdapter; } }

        public IAuthUserAdapter AuthUserAdapter { get { return _authUserAdapter; } }

        public string ConnectionString
        {
            get { return _configuration.GetConnectionString("DefaultConnection"); }
        }

        public List<string> PageMessages
        {
            get { return _tempData["PageMessages"] as List<string>; }
        }

        public List<string> PageWarnings
        {
            get { return _tempData["PageWarnings"] as List<string>; }
        }

        public List<string> PageAlerts
        {
            get { return _tempData["PageAlerts"] as List<string>; }
        }

        public string ControllerName
        {
            get { return _tempData["ControllerName"] as string; }
        }

        public string ActionName
        {
            get { return _tempData["ControllerAction"] as string; }
        }

        public string ElapsedTime
        {
            get { return _tempData["ElapsedTime"] as string; }
        }

        public string AppVersion { get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); }  }
    }
}
