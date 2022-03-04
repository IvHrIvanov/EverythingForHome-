using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;
using System.Diagnostics;

namespace ProjectEverything.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EverythingForHomeDBContext data;

        public HomeController(ILogger<HomeController> logger, EverythingForHomeDBContext data)
        {
            _logger = logger;
            this.data = data;
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