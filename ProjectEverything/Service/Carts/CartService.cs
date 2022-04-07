using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Models;

namespace ProjectEverything.Service.Carts
{
    public class CartService : ICartService
    {
        private readonly EverythingForHomeDBContext data;

        public CartService(EverythingForHomeDBContext data)
        {
            this.data = data;
        }


        public Account AccountById(string accountId) => data.Users
                .Include(x => x.Orders)
                .ThenInclude(x => x.Products)
                .Where(x => x.Id == accountId)
                .Select(x => x)
                .FirstOrDefault();

        public List<Account> GetAccounts(string id)=> data.Users
                .Where(x => x.Id == id)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Products)
                .ToList();

        public Product ProductById(int productId)
            => data.Products.Where(x => x.Id == productId).FirstOrDefault();

        public void RemoveProductFromOrder(Account account, Product product)
        {
            foreach (var order in account.Orders)
            {
                if (order.Products.Contains(product))
                {
                    product.Quantity += product.QuantityBuy;
                    product.QuantityBuy = 0;
                    data.Products.Update(product);
                    data.Orders.Remove(order);
                    data.SaveChanges();
                    break;
                }
            }
        }
    }
}
