using DataBaseevEverythingForHome.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Models;
using System.Linq;

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

        public IActionResult Show([FromQuery] CartAddedProducts cart)
        {
            var order = data.Orders
                .Include(x=>x.Products)
                .Where(x => x.AccountId == 1)
                .FirstOrDefault();

            cart.Order = order;
            return View(cart);
        }
    }
}
