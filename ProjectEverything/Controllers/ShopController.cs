using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Models;
using ProjectEverything.Models.ElectricPart;
using System.Linq;

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
            ;
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

        public IActionResult AddToCart(AllProductsQuaryModel cart)
        {
            ;
            if (cart.QuantityBuy <= 0)
            {
                return RedirectToAction(nameof(Parts));
            }
            var order = new Order();
            var accountOrder = data.Accounts
                .Include(x => x.Orders)
                .Where(x => x.Id == "1")
                .ToList()
                .FirstOrDefault();

            if (accountOrder.Orders.Count == 0)
            {
                int nextOrder = accountOrder.Orders.Sum(x => x.OrderNumber);
                order = new Order()
                {

                    OrderNumber = nextOrder + 1,
                    Products = new List<Product>()
                };
            }
            var product = data.Products
                .Where(x => x.Id == cart.ProductId)
                .FirstOrDefault();


            accountOrder.Id = "1";
            product.Quantity -= cart.QuantityBuy;
            product.QuantityBuy += cart.QuantityBuy;
            order.Products.Add(product);
            accountOrder.Orders.Add(order);
            this.data.Accounts.Add(accountOrder);
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

            var partForm = new Product
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
