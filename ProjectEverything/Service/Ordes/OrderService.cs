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
            try
            {
                var orderData = data.Accounts.Include(x => x.Orders).ThenInclude(x => x.Products).Where(x => x.Id == userId).FirstOrDefault();
                foreach (var order in orderData.Orders)
                {

                    data.Orders.Remove(order);
                }
                data.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new InvalidOperationException("Some data is wrong!");
            }
      
        }
        public async void RemoveFromCartReturnQuantityOfProducts(string userId)
        {
            try
            {
                var orderData = data.Accounts.Include(x => x.Orders).ThenInclude(x => x.Products).Where(x => x.Id == userId).FirstOrDefault();
                foreach (var order in orderData.Orders)
                {
                    foreach (var product in order.Products)
                    {
                        var productForUpdate = data.Products.Where(x => x.Id == product.Id).FirstOrDefault();
                        productForUpdate.Quantity += product.QuantityBuy;
                        productForUpdate.QuantityBuy = 0;
                        productForUpdate.Price = product.Price;
                        data.Products.Update(productForUpdate);
                    }
                    data.Orders.Remove(order);
                }
                data.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new InvalidOperationException("Some data is wrong!");
            }

        }

    }
}