using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static SEO.Statistics.WebUI.Startup;

namespace SEO.Statistics.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Response.Redirect("SearchResults/Statistics");
           // Redirect("~/Views/SearchResults/Statistics.cshtml");
            return View("~/Views/SearchResults/Statistics.cshtml");
        }
      


    }
}
