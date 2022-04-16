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
            Account account = new Account()
            {
                
                FirstName = "ivan",
                LastName = "ivanov",
                Email = "ddsada@dab.bg",
                Town = "prd",
                Address="prd",
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
            Order order = new Order();
            order.Products.Add(product);
            account.Orders.Add(order);
            data.Accounts.Add(account);
            data.SaveChanges();
            var accountId = data.Accounts.FirstOrDefault();
            orderService.RemoveProductsFromCartToUser(accountId.Id);
        }
    }
}
