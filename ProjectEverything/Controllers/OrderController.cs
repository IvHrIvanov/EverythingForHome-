using Microsoft.AspNetCore.Mvc;
using ProjectEverything.Infrastucture;
using ProjectEverything.Service;
using ProjectEverything.Views.Order;
using static ProjectEverything.WebConstants;

namespace ProjectEverything.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Order()
        {
            try
            {
                TempData[GlobalMessage] = $"Thank you for Purchase";
                orderService.RemoveProductsFromCartToUser(GetUserId());
                return View();
            }
            catch (Exception)
            {

                throw new InvalidOperationException("User or products not valid");
            }

        }
        public IActionResult CancelOrder()
        {
            try
            {
                orderService.RemoveFromCartReturnQuantityOfProducts(GetUserId());
                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {

                throw new InvalidOperationException("User or products not valid");
            }

        }
        private string GetUserId() => User.GetId();

    }
}
