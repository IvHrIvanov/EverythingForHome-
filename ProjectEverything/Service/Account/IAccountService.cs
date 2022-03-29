using DataBaseevEverythingForHome.Models;

namespace ProjectEverything.Service.Users
{
    public interface IAccountService
    {
         bool IsUser(string userId);

        Account User(string userId);

    }
}
