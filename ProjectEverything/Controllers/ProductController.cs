using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;
using ProjectEverything.Models.ElectricPart;
using ProjectEverything.Service.Shop;
using ProjectEverything.Service.Users;

namespace ProjectEverything.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IAccountService accountService;
        public ProductController(IProductService products, IAccountService accountService)
        {

            this.productService = products;
            this.accountService = accountService;
        }
        public IActionResult Parts([FromQuery] QuaryModel quary)
        {

            var partsQuaryable = this.productService.Products();

            if (!String.IsNullOrWhiteSpace(quary.SearchTerm))
            {
                partsQuaryable = this.productService.AllProducts(quary.SearchTerm);

            }
            var parts = partsQuaryable
                .Skip((quary.CurrentPage - 1) * QuaryModel.PartsPerPage)
                .Take(QuaryModel.PartsPerPage)
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

        public IActionResult AddToCart(QuaryModel cart)
        {
            if (cart.QuantityBuy <= 0)
            {
                return RedirectToAction(nameof(Parts));
            }
            var order = new Order();
            var account = accountService.User(cart.AccountId);

            if (account.Orders.Count == 0)
            {
                int nextOrder = account.Orders.Sum(x => x.OrderNumber);
                order = new Order()
                {
                    OrderNumber = nextOrder + 1,
                    Products = new List<Product>()
                };
            }
            var product = this.productService.Product(cart.ProductId);
            this.productService.ProductToCart(order, product, account, cart.QuantityBuy);
            return RedirectToAction(nameof(Parts));
        }

        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(AddPartFormModel product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            this.productService.Create
                 (
                 product.Part,
                 product.Year,
                 product.Price,
                 product.Quantity,
                 product.ImageUrl,
                 product.Description
                 );
            return RedirectToAction(nameof(Add));
        }
    }
}