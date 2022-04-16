using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using Microsoft.AspNetCore.Identity;
using Moq;
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
            var account = CreateAccount();

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
            var account = CreateAccount();

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
            var account = CreateAccount();

            var result = accountService.IsUser(account.Id);
            Assert.False(result);
        }
        [Fact]
        public void IsRegister()
        {
            using var data = DatabaseMock.Instance;
            var accountService = new AccountService(data);
            var account = CreateAccount();

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
        [Fact]
        public void IsLogged()
        {
            using var data = DatabaseMock.Instance;
            var accountService = new AccountService(data);
            var account = CreateAccount();
            data.Accounts.Add(account);
            data.SaveChanges();
            LoginFormModel login = new LoginFormModel()
            {
                Email = account.Email,

            };
            var currentAccount = data.Accounts.Select(x => x).FirstOrDefault();

            Assert.NotNull(currentAccount);
        }
        private Account CreateAccount()
        {
            return  new Account()
            {
                UserName = "Ivan@abv.bg",
                Email = "Ivan@abv.bg",
                FirstName = "ivan",
                LastName = "ivanov",
                Town = "Provadia",
                Address = "HG",

            };
        }
    }
}