using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model.Options.Product1
{
    public class CreateProductOptions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }

    }
}
