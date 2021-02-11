using SEO.Statistics.Service.Common;
using SEO.Statistics.Service.Interfaces;
using SEO.Statistics.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace SEO.Statistics.Service.Services
{
    public class BingSearchEngineService : ISearchEngineService
    {
 
        /// <summary>
        /// This method should have code to call Bing API and return results list
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="webUriBasePath"></param>
        /// <returns></returns>
        public List<SearchResult> PerformSearchAndGetResults(string keyword, string webUriBasePath)
        {
            // it is loading json collection from a static mock file
            // in reality it will call Bing API with keyword and get results collection and transform the collection into List<SearchResult>
            string endPointUrl = $"{webUriBasePath}/mock_data/bing_mock1.json";

            var result = new List<SearchResult>();

            var response = new HttpResponseMessage();

            using (var apiClient = new HttpClient())
            {
                try
                {
                    response = apiClient.GetAsync(endPointUrl).Result;

                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //convert external type to entity
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = CommonHelper.DeserializeContent<List<SearchResult>>(responseContent);
                    }
                }
                catch (Exception ae)
                {
                    ///log error
                }
            }

            return result;
        }

    }
}
