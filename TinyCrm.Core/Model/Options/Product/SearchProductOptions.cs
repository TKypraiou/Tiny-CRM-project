using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model.Options.Product1
{
    public class SearchProductOptions
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceRange { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
    }
}
