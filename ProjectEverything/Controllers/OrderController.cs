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
            TempData[GlobalMessage] = $"Thank you for Purchase";
          
            orderService.RemoveProductsFromCartToUser(GetUserId());
            return View();
        }
        public IActionResult CancelOrder()
        {
            orderService.RemoveFromCartReturnQuantityOfProducts(GetUserId());
            return RedirectToAction("Index","Home");
        }
        private string GetUserId() =>User.GetId();
        
    }
}
