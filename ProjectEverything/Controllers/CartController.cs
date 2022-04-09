using DataBaseevEverythingForHome.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Infrastucture;
using ProjectEverything.Models;
using ProjectEverything.Service.Carts;

namespace ProjectEverything.Controllers
{
    public class CartController : Controller
    {
        private readonly SignInManager<Account> signInManager;
        private readonly ICartService cartService;


        public CartController(ICartService cartService)
        {

            this.cartService = cartService;
        }

        public IActionResult CartProduct([FromQuery] CartProducts cart)
        {
            var id = this.User.GetId();
            if (id == null)
            {
                return NotFound();
            }
            var order = cartService.AccountById(id);

            cartService.ShowProductsOnCart(order, cart);

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