using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using ProjectEverything.Models;
using ProjectEverything.Service.Users;

namespace ProjectEverything.Service.User
{
    public class AccountService : IAccountService
    {
        private readonly EverythingForHomeDBContext data;
        public AccountService(EverythingForHomeDBContext data)
        {
            this.data = data;
        }

        public Account CraeateAccount(RegisterFormModel user)
            => new Account()
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Town = user.Town,
                Address = user.Address,
            };

        public bool IsUser(string userId)
            => this.data
            .Accounts
            .Any(x => x.Id == userId);

        public Account GetUser(string userId)
        => this.data.Accounts
            .Where(x => x.Id == userId)
            .FirstOrDefault();
    }
}
