using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
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
            var returnedAccount=cartService.AccountById(account.Id);
            var acc = data.Accounts.Select(x => x).FirstOrDefault();
            Assert.Equal(acc, returnedAccount);
        }
       [Fact]
       public void IsProductIsShowInCar()
        {

        }
    }
}
