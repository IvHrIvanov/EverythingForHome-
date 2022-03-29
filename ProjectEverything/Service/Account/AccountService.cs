using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
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
        public bool IsUser(string userId)
            => this.data
            .Accounts
            .Any(x => x.Id == userId);

        public Account User(string userId)
        => this.data.Accounts
            .Where(x => x.Id == userId)
            .FirstOrDefault();
    }
}
