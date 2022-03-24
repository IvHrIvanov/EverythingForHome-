using DataBaseevEverythingForHome.Database;
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
    }
}
