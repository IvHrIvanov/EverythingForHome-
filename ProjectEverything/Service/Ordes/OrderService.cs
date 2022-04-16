using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using Microsoft.EntityFrameworkCore;
using ProjectEverything.Views.Order;

namespace ProjectEverything.Service
{
    public class OrderService : IOrderService
    {
        private readonly EverythingForHomeDBContext data;

        public OrderService(EverythingForHomeDBContext data)
        {
            this.data = data;
        }

        public async void RemoveProductsFromCartToUser(string userId)
        {
            var orderData = data.Accounts.Include(x => x.Orders).ThenInclude(x => x.Products).Where(x => x.Id == userId).FirstOrDefault();
            foreach (var order in orderData.Orders)
            {

                data.Orders.Remove(order);
            }
            data.SaveChangesAsync();         
        }
    }
}