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
            try
            {
                var order = cartService.AccountById(id);

                cartService.ShowProductsOnCart(order, cart);

                return View(cart);
            }
            catch (ArgumentNullException)
            {

                throw new ArgumentNullException("Account cannot be find");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot show products on cart");
            }

        }

        public IActionResult RemovePart(CartProducts cart)
        {
            try
            {
                var user = cartService.AccountById(cart.AccountId);
                var product = cartService.ProductById(cart.ProductId);
                cartService.RemoveProductFromOrder(user, product);
                return RedirectToAction(nameof(CartProduct));
            }
            catch (ArgumentNullException)
            {

                throw new ArgumentNullException("User or product not registered");
            }

        }
    }
}