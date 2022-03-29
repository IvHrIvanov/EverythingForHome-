using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;

namespace ProjectEverything.Service.Shop
{
    public class ShopService : IShopService
    {
        private readonly EverythingForHomeDBContext data;

        public ShopService(EverythingForHomeDBContext data)
        {
            this.data = data;
        }

        public int Create(string part, string year, decimal price, int quantity,string imageUrl, string description)
        {
            var productData = new Product
            {
                Part = part,
                Year = year,
                Price = price,
                Quantity = quantity,
                ImageUrl = imageUrl,
                Description = description
            };
            this.data.Products.Add(productData);
            this.data.SaveChanges();
            return productData.Id;
        }
    }
}
