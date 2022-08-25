using Data;
using Microsoft.AspNetCore.Mvc;
using SwanseaBreweryStaff.Models;
using System.Diagnostics;

namespace SwanseaBreweryStaff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BreweryContext _breweryContext;

        public HomeController(ILogger<HomeController> logger, BreweryContext breweryContext)
        {
            _logger = logger;
            _breweryContext = breweryContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}