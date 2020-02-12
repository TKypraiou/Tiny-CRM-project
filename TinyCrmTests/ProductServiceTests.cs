using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options.Product1;
using TinyCrm.Core.Services.Product1;
using Xunit;

namespace TinyCrmTests
{
    public class ProductServiceTests
    {
        private TinyCrmDbContext context_;
        public ProductServiceTests()
        {
            context_ = new TinyCrmDbContext();
        }

        [Fact]
        public void CreateProduct_Success() 
        {
            IProductService productService = new ProductService(context_);

            var optionsCreate = new CreateProductOptions()
            {
                 Name = "Mac",
                 Category = ProductCategory.Computers,
                 Price = 1000
            };
            
            var product = productService.CreateProduct(optionsCreate);

            var optionsSearch = new SearchProductOptions()
            {
                Name = optionsCreate.Name,
                Description = optionsCreate.Description,
                Price = optionsCreate.Price
            };

            var products = productService.Search(optionsSearch);

            Assert.NotNull(product);
            Assert.Equal(optionsSearch.Name, product.Name);
            Assert.Equal(optionsSearch.Description, product.Description);
            Assert.Equal(optionsSearch.Price, product.Price);
            Assert.NotEqual(default(Guid), product.Id);
        }

        [Fact]
        public void CreateProduct_Fail_Invalid_Price()
        {
            IProductService productService = new ProductService(context_);

            var optionsCreate = new CreateProductOptions()
            {
                Name = "Apple",
                Category = ProductCategory.Computers,
                Price = 0
            };

            var product = productService.CreateProduct(optionsCreate);

            Assert.Null(product);
        }

        [Fact]
        public void CreateProduct_Fail_Invalid_Description()
        {
            ProductService productService = new ProductService(context_);

            var optionsCreate = new CreateProductOptions()
            {
                Name = "MacBook",
                Price = 2500,
                Description = "" 
            };

            var product = productService.CreateProduct(optionsCreate);

            Assert.Null(product);
        }

        [Fact]
        public void CreateProduct_Fail_Invalid_Name()
        {
            ProductService productService = new ProductService(context_);

            var optionsCreate = new CreateProductOptions()
            {
                Name = null,
                Price = 2500,
                //Category = ProductCategory.Computers,
                Description = "MacBook Pro"
            };

            var product = productService.CreateProduct(optionsCreate);

            Assert.Null(product);

            optionsCreate = new CreateProductOptions()
            {
                Name = "    ",
                Price = 2500,
                //Category = ProductCategory.Computers,
                Description = "MacBook Pro"
            };

            product = productService.CreateProduct(optionsCreate);

            Assert.Null(product);
        }
    }
}
