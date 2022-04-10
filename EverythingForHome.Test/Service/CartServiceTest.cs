using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using ProjectEverything.Models;
using ProjectEverything.Service.Carts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EverythingForHome.Test.Service
{
    public class CartServiceTest
    {
        [Fact]
        public void IsReturnAccountById()
        {
            using var data = DatabaseMock.Instance;
            var cartService = new CartService(data);
            Account account = new Account()
            {
                FirstName = "ivan",
                LastName = "ivanov",
                Email = "ddsada@dab.bg",
                Town = "prd",
                Address = "prd",
                Orders = new List<Order>()

            };
            data.Accounts.Add(account);
            data.SaveChanges();
            var returnedAccount = cartService.AccountById(account.Id);
            var acc = data.Accounts.Select(x => x).FirstOrDefault();
            Assert.Equal(acc, returnedAccount);
        }
        [Fact]
        public void IsProductIsShowInCar()
        {
            using var data = DatabaseMock.Instance;
            var cartService = new CartService(data);
            Account account = new Account()
            {
                FirstName = "ivan",
                LastName = "ivanov",
                Email = "ddsada@dab.bg",
                Town = "prd",
                Address = "prd",
                Orders = new List<Order>()

            };
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Description = "Dadadadadadadad",
                Price = 2.4m,
                Quantity = 1,
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2020"
            };
            CartProducts cartProducts = new CartProducts()
            {
                AccountId = account.Id,
                Product = product,
                ProductId = 1,
                Products = new List<Product>(),
                Quantity = 1
            };
            data.Products.Add(product);
            data.Products.Add(product);
            data.SaveChanges();
            cartService.ShowProductsOnCart(account, cartProducts);
        }
        [Fact]
        public void IsProductById()
        {
            using var data = DatabaseMock.Instance;
            var cartService = new CartService(data);
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Description = "Dadadadadadadad",
                Price = 2.4m,
                Quantity = 1,
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2020"
            };
            data.Products.Add(product);
            data.SaveChanges();
          var getProduct=  cartService.ProductById(product.Id);
            Assert.Equal(getProduct, product);
        }
        [Fact]
        public void IsRemovedProductFromOrder()
        {
            using var data = DatabaseMock.Instance;
            var cartService = new CartService(data);
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Description = "Dadadadadadadad",
                Price = 2.4m,
                Quantity = 1,
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
            data.Accounts.Add(account);
            data.Products.Add(product);
            data.SaveChanges();
            cartService.RemoveProductFromOrder(account,product);
        }
    }
}
