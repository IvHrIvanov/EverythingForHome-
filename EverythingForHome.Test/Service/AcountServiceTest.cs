using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using ProjectEverything.Models;
using ProjectEverything.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EverythingForHome.Test.Service
{
    public class AcountServiceTest
    {
        [Fact]
        public void IsGetUser()
        {
            using var data = DatabaseMock.Instance;
            var accountService = new AccountService(data);
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
            var result = accountService.GetUser(account.Id);
            Assert.Equal(result, account);
        }
        [Fact]
        public void IsUser()
        {
            using var data = DatabaseMock.Instance;
            var accountService = new AccountService(data);
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
            var result = accountService.IsUser(account.Id);
            Assert.True(result);
        }
        [Fact]
        public void IsUserFalse()
        {
            using var data = DatabaseMock.Instance;
            var accountService = new AccountService(data);
            Account account = new Account()
            {
                FirstName = "ivan",
                LastName = "ivanov",
                Email = "ddsada@dab.bg",
                Town = "prd",
                Address = "prd",
                Orders = new List<Order>()

            };
            var result = accountService.IsUser(account.Id);
            Assert.False(result);
        }
        [Fact]
        public void IsRegister()
        {
            using var data = DatabaseMock.Instance;
            var accountService = new AccountService(data);
            Account account = new Account()
            {

                UserName = "ddsada@dab.bg",
                Email = "ddsada@dab.bg",
                FirstName = "ivan",
                LastName = "ivanov",
                Town = "prd",
                Address = "prd",

            };
            RegisterFormModel register = new RegisterFormModel()
            {

                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Town = account.Town,
                Address = account.Address,
            };

            var result = accountService.CraeateAccount(register);
        }
    }
}
