using System.Linq;

namespace EverythingForHome.Test.ProductServiceTest
{
    using DataBaseevEverythingForHome.Models;
    using EverythingForHome.Test.Mock;
    using ProjectEverything.Models;
    using ProjectEverything.Service;
    using System.Collections.Generic;
    using Xunit;
    public class ProductServiceTest
    {
        private const string Url = @"https://upload.wikimedia.org/wikipedia/commons/thumb/f/f0/Scotch_marine_boiler.jpg/220px-Scotch_marine_boiler.jpg";
        [Fact]
        public void IsReturnedProductsWhenIsSearched()
        {
            using var data = DatabaseMock.Instance;
            string findProduct = "Cabel";
            Product product = CreateProduct();
            data.Products.Add(product);
            data.SaveChanges();
            var productService = new ProductService(data);
            var returnFromDB = data.Products.Where(x => x.Part.Contains(findProduct));
            var searchedProduct = productService.AllProducts(findProduct);
            Assert.Equal(returnFromDB, searchedProduct);
        }
        [Fact]
        public void IsReturnedProductFromDbById()
        {
            //Arrange
            const int productId = 1;
            using var data = DatabaseMock.Instance;
            Product product = CreateProduct();
            data.Products.Add(product);
            data.SaveChanges();
            var productService = new ProductService(data);
            var result = productService.Product(productId);
            Assert.Equal(result, product);
        }
        [Theory]
        [InlineData("Boiler", "2020", 200.5, 2, Url, "Best Boiler Ever")]
        public void IsCreatedProduct(string part, string year, decimal price, int quantity, string Url, string description)
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);

            productService.Create(part, year, price, quantity, Url, description);


        }
        [Fact]
        public void IsProductsQuaryable()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            productService.Products();
        }
        [Theory]
        [InlineData(1)]
        public void IsReturnedProductById(int productId)
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            productService.ProductById(productId);
        }
        [Fact]
        public void IsRemovedFromDb()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            Product product = CreateProduct();
            data.Products.Add(product);
            data.SaveChanges();
            QuaryModel quaryModel = new QuaryModel()
            {
                ProductId=product.Id,
                QuantityBuy=2,
                SearchTerm="Cabel",
                AccountId="1",

                Products= new List<ProductViewModel>()
            };
            productService.ProductRemoveDB(quaryModel);
        }
        [Fact]
        public void IsCreatedOrder()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            Product product = CreateProduct();
            data.Products.Add(product);
            data.SaveChanges();
            var allProducts = data.Products.Select(x => x);
            Account account = CreateAccount();
            
            productService.CreateOrder(account);
        }
        [Fact]
        public void IsCreatedOrderWithOrders()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            Product product = CreateProduct();
            data.Products.Add(product);
            data.SaveChanges();
            var allProducts = data.Products.Select(x => x);
            Account account = CreateAccount();
            Order order = new Order();
            account.Orders.Add(order);
            productService.CreateOrder(account);
        }
        [Fact]
        public void IsAddedProductToCart()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            int quantityBuy = 2;
            Product product = CreateProduct();
            Account account = CreateAccount();
            Order order = new Order()
            {
                Id=1,
                OrderNumber=222,
                Products = new List<Product>()
            };
            productService.ProductToCart(order, product, account, quantityBuy);
        }
        private Account CreateAccount()
        {
            return new Account()
            {

                UserName = "Ivan@abv.bg",
                Email = "Ivan@abv.bg",
                FirstName = "ivan",
                LastName = "ivanov",
                Town = "Provadia",
                Address = "HG",

            };
        }
        private Product CreateProduct()
        {
            return new Product()
            {
                Id = 1,
                Part = "Cabel",
                Price = 2,
                Quantity = 1,
                Description = "BEST  EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2021"
            };
        }


    }
}

