using DataBaseevEverythingForHome.Database;
using DataBaseevEverythingForHome.Models;
using ProjectEverything.Models;
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

        public List<ProductViewModel> ProductModel(IQueryable<Product> partsQuaryable, QuaryModel quary)
             => partsQuaryable
                 .Skip((quary.CurrentPage - 1) * QuaryModel.PartsPerPage)
                 .Take(QuaryModel.PartsPerPage)
                 .Select(x => new ProductViewModel
                 {
                     Id = x.Id,
                     Part = x.Part,
                     Price = x.Price,
                     ImageUrl = x.ImageUrl,
                     Quantity = x.Quantity,
                     Description = x.Description,
                     Year = x.Year
                 })
                 .ToList();


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

        public Product ProductById(int productId)
            => data.Products.Where(x => x.Id == productId).FirstOrDefault();

        public Order CreateOrder(Account account)
        {
            Order order = new Order();
            if (account.Orders.Count == 0)
            {
                int nextOrder = account.Orders.Sum(x => x.OrderNumber);
                order = new Order()
                {
                    OrderNumber = nextOrder + 1,
                    Products = new List<Product>()
                };
            }
            return order;
        }

        public void ProductRemoveDB(QuaryModel product)
        {
            var productData = data.Products.Where(x => x.Id == product.ProductId).FirstOrDefault();
            data.Products.Remove(productData);
            data.SaveChanges();
        }
    }
}