using Microsoft.Extensions.Logging;
using SEO.Statistics.Service.Interfaces;
using SEO.Statistics.WebUI.Common;
using SEO.Statistics.WebUI.Models;
using SEO.Statistics.WebUI.ViewModelServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static SEO.Statistics.WebUI.Startup;

namespace SEO.Statistics.WebUI.ViewModelServices
{
    public class SearchEngineViewModelService : ISearchEngineViewModelService
    {
        private readonly ILogger<SearchEngineViewModelService> _logger;
        private readonly ServiceResolver _serviceAccessor;

        public SearchEngineViewModelService(ServiceResolver serviceAccessor, ILogger<SearchEngineViewModelService> logger)
        {
            _serviceAccessor = serviceAccessor;
            _logger = logger;
        }

        /// <summary>
        /// This method should contain common logic for ViewModel handling 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="currentWebUIBasePath"></param>
        /// <returns></returns>
        public string GetSeoStatistics(SearchEngineInputViewModel viewModel, string currentWebUIBasePath)
        {
            // all these 
            ISearchEngineService searchEngineService = _serviceAccessor(viewModel.SearchEngineType);

            var allResults = searchEngineService.PerformSearchAndGetResults(viewModel.SearchKeyWord, currentWebUIBasePath);

            if (!allResults.Any())
                return CommonConstants.ZeroResult;

            //we are interested in top 100 results only
            var searchResult = allResults.Take(CommonConstants.TopNumberOfResults);

            var positionList = new List<int>();
            int count = 1;

            foreach (var item in searchResult)
            {
                if (item.Link.Contains(CommonConstants.SympliLinkToSearch, System.StringComparison.InvariantCultureIgnoreCase))
                    positionList.Add(count);

                count++;
            }

            if (!positionList.Any())
                return CommonConstants.ZeroResult;

            return string.Join(',', positionList);
        }
    }
}
