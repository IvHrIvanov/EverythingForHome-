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
        public IActionResult Parts([FromQuery] AllProductsQuaryModel quary)
        {
            var partsQuaryable = data.Products.AsQueryable();

            if (!String.IsNullOrWhiteSpace(quary.SearchTerm))
            {
                partsQuaryable = data.Products
                    .Where(x => x.Part.Contains(quary.SearchTerm));

            }
            var productModel = new List<ProductViewModel>();
            var parts = partsQuaryable
                .Skip((quary.CurrentPage - 1) * AllProductsQuaryModel.PartsPerPage)
                .Take(AllProductsQuaryModel.PartsPerPage)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Part = x.Part,
                    Price = x.Price,
                    ImageUrl = x.ImageUrl,
                    Quantity = x.Quantity,
                    Description = x.Description,
                    Year = x.Year
                })
                .ToList();

            quary.Products = parts;
            return View(quary);
        }

        public IActionResult AddToCart(int productId)
        {

            var product = data.Products.Where(x => x.Id == productId)
                         .FirstOrDefault();

            var order = new Order
            {

                OrderNumber = 12,
                AccountId = 1,
                Products = new List<Products>()

            };

            order.Products.Add(product);

            this.data.Orders.Add(order);
            this.data.SaveChanges();
            return RedirectToAction(nameof(Parts));
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
