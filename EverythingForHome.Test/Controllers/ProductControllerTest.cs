using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using Microsoft.AspNetCore.Authentication;
using ProjectEverything.Controllers;
using ProjectEverything.Models;
using ProjectEverything.Models.ElectricPart;
using ProjectEverything.Service;
using ProjectEverything.Service.User;
using Xunit;

namespace EverythingForHome.Test.Controllers
{
    public class ProductControllerTest
    {
        private static string CABEL = "Cabel";
        private static string BOILER = "Boiler";

        [Fact]
        public void IsProductSearchIsNull()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            string findProduct = CABEL;
            var product = CreateProduct();

            data.Products.Add(product);
            data.SaveChanges();

            QuaryModel quary = new QuaryModel()
            {
                SearchTerm = null
            };
            productController.AllProducts(quary);
        }
        [Fact]
        public void IsProductSearchIsNotNull()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            string findProduct = CABEL;
            var product = CreateProduct();

            data.Products.Add(product);
            data.SaveChanges();
            QuaryModel quary = new QuaryModel()
            {
                SearchTerm = CABEL
            };
            productController.AllProducts(quary);

        }
        [Fact]
        public void IsControllerNotAddProductToCart()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);

            QuaryModel quary = new QuaryModel()
            {
                QuantityBuy = -1
            };
            productController.AddToCart(quary);

        }
        [Fact]
        public void IsAddProductToDb()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            string findProduct = CABEL;
            var product = CreateProduct();

            ProductFormModel formModel = CreateProductForMModel(product);
            productController.CreateProduct(formModel);
        }
        [Fact]
        public void IsRemoveFromDb()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            var product = CreateProduct();

            QuaryModel quaryModel = CreateProduct(product);
            data.Products.Add(product);
            data.SaveChanges();
            productController.RemoveProductFromDB(quaryModel);
        }
        [Fact]
        public void IsEdited()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            var product = CreateProduct();

            QuaryModel quaryModel = CreateProduct( product);

            productController.EditProduct(quaryModel);
        }

        [Fact]
        public void IsModelNotValid()
        {

            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);

            ProductFormModel formModel = new ProductFormModel()
            {
                Part = BOILER
            };

            productController.CreateProduct(formModel);
        }
        [Fact]
        public void IsUpdatedCurrentProduct()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            ProductFormModel updateProduct = new ProductFormModel();

            productController.UpdateProduct(updateProduct);
        }


        private QuaryModel CreateProduct(Product product)
        {
            return new QuaryModel()
            {
                ProductId = product.Id,

            };
        }
        private Product CreateProduct()
        {
            return new Product()
            {
                Id = 1,
                Part = CABEL,
                Price = 2,
                Quantity = 1,
                Description = "BEST  EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2021"
            };
        }
        private ProductFormModel CreateProductForMModel(Product product)
        {
            return new ProductFormModel()
            {

                Part = product.Part,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Year = product.Year,
                Price = product.Price,
                Quantity = 1

            };
        }

    }
}
