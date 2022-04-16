using DataBaseevEverythingForHome.Models;
using EverythingForHome.Test.Mock;
using ProjectEverything;
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
        [Fact]
        public void IsProductSearchIsNull()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            string findProduct = "Cabel";
            Product product = new Product()
            {
                Id = 1,
                Part = findProduct,
                Description = "BEST CABEL EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2020"
            };
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
            string findProduct = "Cabel";
            Product product = new Product()
            {
                Id = 1,
                Part = findProduct,
                Description = "BEST CABEL EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2020"
            };
            data.Products.Add(product);
            data.SaveChanges();
            QuaryModel quary = new QuaryModel()
            {
                SearchTerm = "Cabel"
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
            string findProduct = "Cabell";
            Product product = new Product()
            {
                Id = 1,
                Part = findProduct,
                Price = 2,
                Quantity = 1,
                Description = "BEST  EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2021"
            };
            ProductFormModel formModel = new ProductFormModel()
            {

                Part = product.Part,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Year = product.Year,
                Price = product.Price,
                Quantity = 1

            };
            productController.CreateProduct(formModel);
        }
        [Fact]
        public void IsRemoveFromDb()
        {
            using var data = DatabaseMock.Instance;
            var productService = new ProductService(data);
            var acountService = new AccountService(data);
            var productController = new ProductController(productService, acountService);
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Price = 2,
                Quantity = 1,
                Description = "BEST  EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2021"
            };
            QuaryModel quaryModel = new QuaryModel()
            {
                ProductId = product.Id,

            };
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
            Product product = new Product()
            {
                Id = 1,
                Part = "Cabel",
                Price = 2,
                Quantity = 1,
                Description = "BEST  EVER!",
                ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
                Year = "2021"
            };
            QuaryModel quaryModel = new QuaryModel()
            {
                ProductId = product.Id,

            };
            data.Products.Add(product);
            data.SaveChanges();
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
                Part = "Boiler"
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

        //[Fact]
        //public void IsControllerAddProductToCart()
        //{
        //    using var data = DatabaseMock.Instance;
        //    string findProduct = "Cabel";
        //    Product product = new Product()
        //    {
        //        Id = 1,
        //        Part = findProduct,
        //        Description = "BEST CABEL EVER!",
        //        ImageUrl = "https://www.pyramis.gr/inst/pyramis_6/gallery/product_photos/028058101.jpg",
        //        Year = "2020"
        //    };
        //    Account account = new Account()
        //    {
        //        FirstName = "ivan",
        //        LastName = "ivanov",
        //        Email = "ddsada@dab.bg",
        //        Town = "prd",
        //        Address = "prd",
        //        Orders = new List<Order>()

        //    };
        //    data.Products.Add(product);
        //    data.Accounts.Add(account);
        //    data.SaveChanges();

        //    var productService = new ProductService(data);
        //    var acountService = new AccountService(data);
        //    var productController = new ProductController(productService, acountService);
        //    QuaryModel quary = new QuaryModel()
        //    {
        //        AccountId = "1",
        //        QuantityBuy = 1,

        //    };
        //    productController.AddToCart(quary);

        //}
    }
}
