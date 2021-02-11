using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEO.Statistics.Service.Services;
using SEO.Statistics.WebUI.ViewModelServices;
using SEO.Statistics.WebUI.ViewModelServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SEO.Statistics.WebUI.Startup;

namespace SEO.Statistics.WebUI.Common
{
    public static class DIConfig
    {
        public static void ResolveDependencies(IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            //we can use the configuration and hosting env and inject these further in other project's 
            services.AddScoped<ISearchEngineViewModelService, SearchEngineViewModelService>();

            services.AddTransient<GoogleSearchEngineService>();
            services.AddTransient<BingSearchEngineService>();

            services.AddTransient<ServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case SearchEngineType.Google:
                        return serviceProvider.GetService<GoogleSearchEngineService>();
                    case SearchEngineType.Bing:
                        return serviceProvider.GetService<BingSearchEngineService>();
                    default:
                        return serviceProvider.GetService<GoogleSearchEngineService>();
                }
            });


        }
    }
}
