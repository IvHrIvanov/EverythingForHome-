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
            Product product = CreateProduct();

            Account account = CreateAccount();
            Order order = CreateOrder();
            order.Products.Add(product);
            account.Orders.Add(order);
            data.Products.Add(product);
            data.Accounts.Add(account);
            data.SaveChanges();
            CartProducts cartProducts = CreateCartProducts(product, account);

            productController.RemovePart(cartProducts);
        }
        private Product CreateProduct()
        {
            return new Product()
            {
                Id = 1,
                Part = "Cabel",
                Price = 2,
                Quantity = 1,
                Description = "BEST  EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2021"
            };
        }
        private Account CreateAccount()
        {
            return new Account()
            {
                UserName = "Ivan@abv.bg",
                Email = "Ivan@abv.bg",
                FirstName = "ivan",
                LastName = "ivanov",
                Town = "Provadia",
                Address = "HG",
                Orders = new List<Order>()
            };
        }
        private Order CreateOrder()
        {
            return new Order()
            {
                Products = new List<Product>()
            };
        }
        private CartProducts CreateCartProducts(Product product, Account account)
        {
            return new CartProducts()
            {
                Product = product,
                ProductId = product.Id,
                AccountId = account.Id

            };
        }

    }
}
