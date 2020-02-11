using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options.Product1;

namespace TinyCrm.Core.Services.Product1
{
    public interface IProductService 
    {
        public List<Product> Search(SearchProductOptions options);
        public Product CreateProduct(CreateProductOptions options);
        public int SumOfStocks();
    }
}
