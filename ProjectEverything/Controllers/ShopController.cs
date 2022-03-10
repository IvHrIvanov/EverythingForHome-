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
        public IActionResult Parts([FromQuery]AllProductsQuaryModel quary)
        {
            var productModel = new List<ProductViewModel>();
            var allDataFromDataBase = data.Products.AsQueryable();
            var parts = allDataFromDataBase
                .Skip((quary.CurrentPage-1)*AllProductsQuaryModel.PartsPerPage)
                .Take(AllProductsQuaryModel.PartsPerPage)
                .Select(x => new ProductViewModel
                {
                    Part = x.Part,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    Year = x.Year,
                })
                .ToList();
            quary.Products = parts;
            return View(quary);
        }
        public IActionResult SearchProduct(string productName)
        {

            return View();
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
            return RedirectToAction(nameof(Add));
        }
    }
}
