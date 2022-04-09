using DataBaseevEverythingForHome.Models;
using ProjectEverything.Models;

namespace ProjectEverything.Service.Carts
{
    public interface ICartService
    {
        public Account AccountById(string accountId);
        public Product ProductById(int productId);
        public void RemoveProductFromOrder(Account account, Product product);
        public void ShowProductsOnCart(Account account, CartProducts cart);
    }
}
