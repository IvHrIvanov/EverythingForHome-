using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models.ElectricPart;
using ProjectEverything.Models.WaterParts;

namespace ProjectEverything.Controllers
{
    public class ShopController : Controller
    {
        private readonly EverythingForHomeDBContext data;

        public ShopController(EverythingForHomeDBContext data)
        {
            this.data = data;   
        }
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
        public IActionResult Add(AddPartFormModel part)
        {
            if (!ModelState.IsValid)
            {
                
                return View(part);
            }
            var shop = data.Shops.FirstOrDefault();

            var partForm = new ElectricPart
            {
                PartElectric = part.PartElectric,
                Price = part.Price,
                Quantity = part.Quantity,
                CabelMeter = part.CabelMeter,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                Year = part.Year,
                ShopId = shop.Id
            };
            this.data.ElectricsParts.Add(partForm);
            this.data.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
