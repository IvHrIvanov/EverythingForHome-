using DataBaseevEverythingForHome.Models;
using System.Linq;

namespace ProjectEverything.Service.Shop
{
    public interface IProductService
    {
        void Create(
            string part,
            string year,
            decimal price,
            int quantity,
            string imageUrl,
            string description
            );
        void ProductToCart(Order order,Product product,Account account,int quantityBuy);
        Product Product(int productId);
        IQueryable<Product> Products();
        IQueryable<Product> AllProducts(string searchTerm);
    }
}
