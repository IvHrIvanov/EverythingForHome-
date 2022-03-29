using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using ProjectEverything.Service.Shop;

namespace ProjectEverything.Service
{
    public class ProductService : IProductService
    {
        private readonly EverythingForHomeDBContext data;

        public ProductService(EverythingForHomeDBContext data)
        {
            this.data = data;
        }


        public void Create(string part, string year, decimal price, int quantity, string imageUrl, string description)
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
        }

        public Product Product(int productId)
       => this.data.Products.
           Where(x => x.Id == productId)
           .FirstOrDefault();

        public void ProductToCart(Order order, Product product, Account account, int quantityBuy)
        {
            product.Quantity -= quantityBuy;
            product.QuantityBuy += quantityBuy;
            order.Products.Add(product);
            account.Orders.Add(order);
            
            this.data.Orders.Add(order);
            this.data.SaveChanges();
        }
        public IQueryable<Product> AllProducts(string searchTerm)
          => data.Products
                  .Where(x => x.Part.Contains(searchTerm));
        public IQueryable<Product> Products()
        => data.Products.AsQueryable();
    }
}