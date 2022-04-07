using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Infrastucture;
using ProjectEverything.Models;
using ProjectEverything.Service.Carts;

namespace ProjectEverything.Controllers
{
    public class CartController : Controller
    {
        private readonly EverythingForHomeDBContext data;
        private readonly SignInManager<Account> signInManager;
        private readonly ICartService cartService;


        public CartController(EverythingForHomeDBContext data, ICartService cartService)
        {
            this.data = data;
            this.cartService = cartService;
        }

        public IActionResult CartProduct([FromQuery] CartProducts cart)
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
        public IActionResult RemovePart(CartProducts cart)
        {
            var user = cartService.AccountById(cart.AccountId);
            var product = cartService.ProductById(cart.ProductId);
            cartService.RemoveProductFromOrder(user, product);        
            return RedirectToAction(nameof(CartProduct));
        }
    }
}