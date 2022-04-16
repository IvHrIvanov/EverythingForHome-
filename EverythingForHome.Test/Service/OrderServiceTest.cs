using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using ProjectEverything.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EverythingForHome.Test.Service
{
    public class OrderServiceTest
    {
        [Fact]
        public void IsRemovedProductsFromCart()
        {
            using var data = DatabaseMock.Instance;
            var orderService = new OrderService(data);
            Account account = CreateAccount();
            Product product = CreateProduct();
            Order order = new Order();
            order.Products.Add(product);
            account.Orders.Add(order);
            data.Accounts.Add(account);
            data.SaveChanges();
            var accountId = data.Accounts.FirstOrDefault();
            orderService.RemoveProductsFromCartToUser(accountId.Id);
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

            };
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
    }
}
