using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Infrastucture;
using ProjectEverything.Models;
using System.Linq;

namespace ProjectEverything.Controllers
{
    public class CartController : Controller
    {
        private readonly EverythingForHomeDBContext data;
        private readonly SignInManager<Account> signInManager;


        public CartController(EverythingForHomeDBContext data)
        {
            this.data = data;
        }

        public IActionResult Show([FromQuery] CartAddedProducts cart)

        {
            
            var id = this.User.GetId();
            if (id == null)
            {
                return NotFound();
            }
            var order = data.Users
                .Where(x => x.Id == id)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Products)
                .ToList();


            foreach (var item in order)
            {
                foreach (var currentOrder in item.Orders)
                {
                    foreach (var product in currentOrder.Products)
                    {
                        cart.Products.Add(product);
                    }
                }
            }
            ;
            return View(cart);
        }
        public IActionResult RemovePart()
        {
            return RedirectToAction(nameof(Show));
        }
    }
}
