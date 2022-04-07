using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Infrastucture;
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
        private const string adminRole = "Administrator";
        public ProductController(IProductService productService, IAccountService accountService)
        {

            this.productService = productService;
            this.accountService = accountService;

        }
        public IActionResult Product([FromQuery] QuaryModel quary)
        {

            var partsQuaryable = this.productService.Products();

            if (!String.IsNullOrWhiteSpace(quary.SearchTerm))
            {
                partsQuaryable = this.productService.AllProducts(quary.SearchTerm);

            }
            var parts = productService.ProductModel(partsQuaryable, quary);

            quary.Products = parts;
            return View(quary);
        }

        public IActionResult AddToCart(QuaryModel cart)
        {
            if (cart.QuantityBuy <= 0)
            {
                return RedirectToAction(nameof(Product));
            }
            var account = accountService.User(cart.AccountId);
            var order = productService.CreateOrder(account);
            var product = this.productService.Product(cart.ProductId);
            this.productService.ProductToCart(order, product, account, cart.QuantityBuy);
            return RedirectToAction(nameof(Product));
        }

        public IActionResult Add() => View();
        [HttpPost]
        [Authorize]
        public IActionResult Add(ProductFormModel product)
        {
            if (!User.IsInRole(adminRole))
            {
                return Unauthorized();
            }

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
        [Authorize]
        public IActionResult RemoveProductFromDB(QuaryModel product)
        {
            if (!User.IsInRole(adminRole))
            {
                return Unauthorized();
            }
            productService.ProductRemoveDB(product);
            return RedirectToAction("Parts", "Product");
        }
        [Authorize]
        public IActionResult Edit(QuaryModel quary)
        {

            if (!User.IsInRole(adminRole))
            {
            }

            var productData = productService.ProductById(quary.ProductId);

            return View(new ProductFormModel
            {
                Part = productData.Part,
                Year = productData.Year,
                Price = productData.Price,
                Quantity = productData.Quantity,
                ImageUrl = productData.ImageUrl,
                Description = productData.Description
            });
        }

    }

}
