using DataBaseevEverythingForHome.Models;
using ProjectEverything.Models;
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
        public List<ProductViewModel> ProductModel(IQueryable<Product> partsQuaryable, QuaryModel quary);
        public Product ProductById(int productId);
    }
}
