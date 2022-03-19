using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Models;
using System.Linq;

namespace ProjectEverything.Controllers
{
    public class CartController : Controller
    {
        private readonly EverythingForHomeDBContext data;


        public CartController(EverythingForHomeDBContext data)
        {
            this.data = data;
        }

        public IActionResult Show([FromQuery] CartAddedProducts cart)
        {
            cart.Products = new List<Product>();

            var order = data.Orders
                .Include(x => x.Products)
                .Where(x =>x.Products.Count != 0)
                .ToList();

            foreach (var item in order)
            {
                foreach (var currentProduct in item.Products)
                {
                    cart.Products.Add(currentProduct);
                }
            }
            return View(cart);
        }
    }
}
