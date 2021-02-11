using SEO.Statistics.Service.Common;
using SEO.Statistics.Service.Models;
using System.Collections.Generic;

namespace SEO.Statistics.Service.Interfaces
{
    public interface ISearchEngineService
    {
        List<SearchResult> PerformSearchAndGetResults(string keyword, string webUriBasePath);

    }
}
