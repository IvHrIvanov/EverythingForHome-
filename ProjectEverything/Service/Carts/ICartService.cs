using DataBaseevEverythingForHome.Models;
using ProjectEverything.Models;

namespace ProjectEverything.Service.Carts
{
    public interface ICartService
    {
        public Account AccountById(string accountId);
        public Product ProductById(int productId);
        public void RemoveProductFromOrder(Account account, Product product);
        public List<Account> GetAccounts(string id);
        public void AddProductsToCart(List<Account> account, CartProducts cart)
        {
            foreach (var order in account)
            {
                foreach (var currentOrder in order.Orders)
                {
                    foreach (var product in currentOrder.Products)
                    {
                        cart.Products.Add(product);
                    }
                }
            }
        }
    }
}
