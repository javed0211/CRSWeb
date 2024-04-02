using CRSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Define the sidebar options for the home page
            var sidebarOptions = new List<string> { "Reports", "Release Data" };
            ViewBag.SidebarOptions = sidebarOptions;

            // Define the reports
            var reports = new List<Report>
            {
                new Report { Name = "Automation Reports", Url = "automationReportsUrl" },
                new Report { Name = "KPI Reports", Url = "kpiReportsUrl" }
            };

            var page = new Page
            {
                Title = "Centralised Reporting System",
                Reports = reports,
                ReleaseDataUrl = "releaseDataUrl"
            };

            return View(page);
        }

        public IActionResult Privacy()
        {
            return View();
        }
		public IActionResult Admin()
		{
			
			var reports = new List<Report>
			{
				new Report { Name = "Automation Reports", Url = "automationReportsUrl" },
				new Report { Name = "KPI Reports", Url = "kpiReportsUrl" }
			};

			var page = new Page
			{
				Title = "Admin",
				Reports = reports,
				ReleaseDataUrl = "releaseDataUrl"
			};

			return View(page);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
