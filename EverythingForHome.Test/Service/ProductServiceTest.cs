using System.Linq;

namespace EverythingForHome.Test.ProductServiceTest
{
    using DataBaseevEverythingForHome.Models;
    using EverythingForHome.Test.Mock;
    using ProjectEverything.Service;
    using Xunit;
    public class ProductServiceTest
    {
        [Fact]
        public Product IsReturnedProductFromDbById()
        {
            //Arrange
            const int productId = 1;
            using var data = DatabaseMock.Instance;
            Product product = new Product()
            {
                Id = productId,
                Part = "Cabel",
                Description="Dadadadadadadad",
                ImageUrl= "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year="2020"
            };
            data.Products.Add(product);
            data.SaveChanges();
            var productService = new ProductService(data);
            //Act

            var result = productService.Product(product.Id);
            //Assert
            return result;
        }
        [Fact]
        public IQueryable<Product> IsReturnedProductsWhenIsSearched()
        {
            using var data = DatabaseMock.Instance;

            var searchTerm = "Cabel";
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Description = "Dadadadadadadad",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2020"
            };
            data.Products.Add(product);
            data.SaveChanges();
            var productService = new ProductService(data);

            var searchedProduct = data.Products.Where(x => x.Part.Contains(searchTerm));
            return searchedProduct;
        }
    }
}
