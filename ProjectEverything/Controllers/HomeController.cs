using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace ProjectEverything.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacts()
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