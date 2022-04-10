using Microsoft.AspNetCore.Mvc;

namespace ProjectEverything.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Company()
        {
            return View();
        }
    }
}
