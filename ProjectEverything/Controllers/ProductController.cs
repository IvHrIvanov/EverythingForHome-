using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Constants;
using ProjectEverything.Infrastucture;
using ProjectEverything.Models;
using ProjectEverything.Models.ElectricPart;
using ProjectEverything.Service.Shop;
using ProjectEverything.Service.Users;
using static ProjectEverything.WebConstants;

namespace ProjectEverything.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IAccountService accountService;

        public ProductController(IProductService productService, IAccountService accountService)
        {

            this.productService = productService;
            this.accountService = accountService;

        }
        public IActionResult AllProducts([FromQuery] QuaryModel quary)
        {
            var partsQuaryable = this.productService.Products();

            if (!String.IsNullOrWhiteSpace(quary.SearchTerm))
            {
                partsQuaryable = this.productService.AllProducts(quary.SearchTerm);

            }
            var parts = productService.ProductModel(partsQuaryable, quary);
            ViewBag.Allproducts = parts;
            quary.Products = parts;
            return View(quary);
        }

        public IActionResult AddToCart(QuaryModel cart)
        {
            if (cart.QuantityBuy <= 0)
            {
                return RedirectToAction(nameof(AllProducts));
            }
            var accountId = User.GetId();
            var account = accountService.GetUser(accountId);
            var order = productService.CreateOrder(account);
            var product = this.productService.Product(cart.ProductId);
            this.productService.ProductToCart(order, product, account, cart.QuantityBuy);

            return RedirectToAction(nameof(AllProducts));
        }

        public IActionResult CreateProduct() => View();
        [HttpPost]
        [Authorize(Roles = AdminRole.adminRole)]
        public async Task<IActionResult> CreateProduct(ProductFormModel product)
        {

            if (!ModelState.IsValid && product.id != 0)
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
            TempData[GlobalMessage] = $"{product.Part} was create!";

            return RedirectToAction(nameof(CreateProduct));
        }

        [Authorize(Roles = AdminRole.adminRole)]
        public async Task<IActionResult> RemoveProductFromDB(QuaryModel product)
        {
            productService.ProductRemoveDB(product);

            return RedirectToAction(nameof(AllProducts), "Product");
        }
        public IActionResult EditProduct() => View();
        [HttpPost]
        [Authorize(Roles = AdminRole.adminRole)]
        public IActionResult EditProduct(QuaryModel quary)
        {
            var productData = productService.ProductById(quary.ProductId);

            return View(new ProductFormModel
            {
                id = productData.Id,
                Part = productData.Part,
                Year = productData.Year,
                Price = productData.Price,
                Quantity = productData.Quantity,
                ImageUrl = productData.ImageUrl,
                Description = productData.Description
            });
        }
        [Authorize(Roles = AdminRole.adminRole)]
        public IActionResult UpdateProduct(ProductFormModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(EditProduct), product);
            }
            try
            {
                TempData[GlobalMessage] = $"{product.Part} was update!";
                productService.UpdateCurrentProduct(product);
                return RedirectToAction(nameof(AllProducts));
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Something is wrong");
            }
         
        }
    }
}