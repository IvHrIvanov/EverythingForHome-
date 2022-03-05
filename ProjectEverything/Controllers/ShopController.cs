using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;
using ProjectEverything.Models.ElectricPart;

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
            var productModel = new List<ProductViewModel>();
            var allDataFromDataBase = data.Products.Select(x => x).ToArray();
            
            foreach (var item in allDataFromDataBase)
            {
               var product= new ProductViewModel
                {
                    Part=item.Part,
                    Price=item.Price,
                    ImageUrl=item.ImageUrl,
                    Quantity=item.Quantity,
                    Description=item.Description,
                    Year=item.Year,
                };
                productModel.Add(product);
            }
            return View(productModel);
        }
        public IActionResult Add(AddPartFormModel product)
        {
            if (!ModelState.IsValid)
            {
                
                return View(product);
            }
            var shop = data.Shops.FirstOrDefault();

            var partForm = new Products
            {
                Part = product.Part,
                Price = product.Price,
                Quantity = product.Quantity,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Year = product.Year,
                ShopId = shop.Id
            };
            this.data.Products.Add(partForm);
            this.data.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
