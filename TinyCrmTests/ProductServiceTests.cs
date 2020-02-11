using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Data;
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

            var options = new CreateProductOptions()
            {
                 Id = "123",
                 Name = "Mac",
                 Category = TinyCrm.Core.Model.ProductCategory.Computers,
                 Price = 1000
            };
            
            var product = productService.CreateProduct(options);

            Assert.NotNull(product);
        }
    }
}
