using SEO.Statistics.WebUI.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SEO.Statistics.WebUI.Models
{
    public class SearchEngineInputViewModel
    {
        [Display(Name = "Search KeyWord")]
        [Required]
        public string SearchKeyWord { get; set; }

        [Display(Name = "Select Search Engine")]
        public SearchEngineType SearchEngineType { get; set; }

        public string StatisticsResult { get; set; }

        public bool ShowResult { get; set; }
    }
}
