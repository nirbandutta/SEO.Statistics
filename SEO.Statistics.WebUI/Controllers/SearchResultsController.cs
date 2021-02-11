using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SEO.Statistics.Service.Interfaces;
using SEO.Statistics.WebUI.Models;
using SEO.Statistics.WebUI.ViewModelServices.Interfaces;
using System;
using static SEO.Statistics.WebUI.Startup;

namespace SEO.Statistics.WebUI.Controllers
{
    public class SearchResultsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;
        private readonly ISearchEngineViewModelService _searchEngineViewModelService;

        public SearchResultsController(ILogger<HomeController> logger, IMemoryCache cache, ISearchEngineViewModelService searchEngineViewModelService)
        {
            _logger = logger;
            _cache = cache;
            _searchEngineViewModelService = searchEngineViewModelService;
        }

        public ActionResult Statistics()
        {
            return View(new SearchEngineInputViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Statistics(SearchEngineInputViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //the cacheKey is not tied to search engine type only
            //if we want to search different keywords, we need diff implementation of cache
            string cacheKey = $"_SeoPositions_{viewModel.SearchEngineType.ToString()}";
            string currentWebUIBasePath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            var cacheData = GetFromCache(cacheKey);
            
            string fetchedData = string.Empty;

            if (cacheData != null)
            {
                fetchedData = cacheData;
            }
            else
            {
                fetchedData = _searchEngineViewModelService.GetSeoStatistics(viewModel, currentWebUIBasePath);
                SetInCache(cacheKey, fetchedData);
            }

            viewModel.StatisticsResult = fetchedData;
            viewModel.ShowResult = true;
            return View(viewModel);
        }

        private string GetFromCache(string key)
        {
            return _cache.Get<string>(key);
        }

        private void SetInCache(string key, string data)
        {
            _cache.Set<string>(key, data, TimeSpan.FromHours(1));
        }

    }
}
