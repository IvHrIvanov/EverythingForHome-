using Microsoft.AspNetCore.Mvc;
using static ProjectEverything.WebConstants;

namespace ProjectEverything.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            TempData[GlobalMessage] = $"Thank you for Purchase";

            return RedirectToAction("Product","Product");
        }
    }
}
