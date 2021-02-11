
using SEO.Statistics.WebUI.Models;

namespace SEO.Statistics.WebUI.ViewModelServices.Interfaces
{
    public interface ISearchEngineViewModelService
    {
        string GetSeoStatistics(SearchEngineInputViewModel viewModel, string currentWebUIBasePath);
    }
}
