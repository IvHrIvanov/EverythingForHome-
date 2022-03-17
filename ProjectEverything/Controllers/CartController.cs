using DataBaseevEverythingForHome.Database;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Models;

namespace ProjectEverything.Controllers
{
    public class CartController : Controller
    {
        private readonly EverythingForHomeDBContext data;
        private readonly IEnumerable<CartAddedProducts> cartProducts;


        public CartController(EverythingForHomeDBContext data, IEnumerable<CartAddedProducts> cartProducts)
        {
            this.data = data;
            this.cartProducts = cartProducts;
        }

        public IActionResult Show()
        {
            var product = new ProductViewModel();
            var showProducts = data.Orders
                .ToArray()
                .Select(x => new
                {
                    Products = x.Products.Select(p => new
                    {
                        Part = p.Part,
                        Price = p.Price,
                        Year = p.Year,
                        ImageUrl = p.ImageUrl,
                        Description = p.Description,
                        Quantity = p.Quantity
                    })
                });
            return View();
        }
    }
}
