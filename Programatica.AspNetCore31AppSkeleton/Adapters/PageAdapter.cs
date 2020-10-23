using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Programatica.AspNetCore31AppSkeleton.ViewModels;
using System.Collections.Generic;

namespace Programatica.AspNetCore31AppSkeleton.Adapters
{
    public class PageAdapter : IPageAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly HttpContext _httpContext;
        private readonly ITempDataDictionary _tempData;

        public PageAdapter(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _httpContext = _httpContextAccessor.HttpContext;
            _tempData = _tempDataDictionaryFactory.GetTempData(_httpContext);
        }

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

    }
}
