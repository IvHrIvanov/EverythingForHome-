using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using ProjectEverything.Controllers;
using ProjectEverything.Models;
using ProjectEverything.Service.Carts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EverythingForHome.Test.Controllers
{
    public class CartControllerTest
    {

        [Fact]
        public void IsCartProduct()
        {
            using var data = DatabaseMock.Instance;
            var cartService = new CartService(data);
            var productController = new CartController(cartService);
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Description = "BEST CABEL EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2020"
            };

            Account account = new Account()
            {
                FirstName = "ivan",
                LastName = "ivanov",
                Email = "ddsada@dab.bg",
                Town = "prd",
                Address = "prd",
                Orders = new List<Order>()

            };
            Order order = new Order()
            {
                Products = new List<Product>()
            };
            order.Products.Add(product);
            account.Orders.Add(order);
            data.Products.Add(product);
            data.Accounts.Add(account);
            data.SaveChanges();
            CartProducts cartProducts = new CartProducts()
            {
                Product = product,
                ProductId = product.Id,
                AccountId = account.Id

            };

            productController.RemovePart(cartProducts);
        }

    }
}
