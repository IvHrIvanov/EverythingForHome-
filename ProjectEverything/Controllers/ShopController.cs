using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models.WaterParts;

namespace ProjectEverything.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Parts()
        {
            
            Boiler boiler = new Boiler()
            {
                Manufacturer = "Tessy",
                Model = "A321",
                Price = 123.55m,
            };
            ViewBag.Boiler = boiler;
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
