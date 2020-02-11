using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options.Product1;

namespace TinyCrm.Core.Services.Product1
{
    public class ProductService : IProductService
    {
        private TinyCrmDbContext context;
        public ProductService(TinyCrmDbContext dbContext)
        {
            context = dbContext;
        }

        public List<Product> Search(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context
                .Set<Product>()
                .AsQueryable();

            if (options.Id != null)
            {
                query = query.Where(
                    p => p.Id == options.Id);
            }

            if (options.Name != null)
            {
                query = query.Where(c => c.Name.Contains(options.Name));
            }

            if (options.Description != null)
            {
                query = query.Where(p => p.Description.Contains(options.Description));
            }

            if (options.MinValue != 0)
            {
                query = query.Where(p => p.Price >= options.MinValue);
            }

            if (options.MaxValue != 0)
            {
                query = query.Where(p => p.Price <= options.MaxValue);
            }

            return query.ToList();
        }

        public Product CreateProduct(CreateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Id)
                || string.IsNullOrWhiteSpace(options.Name)
                || options.Price <= 0)
            {
                return null;
            }

            var product = new Product();

            if (product != null)
            {
                return null;
            }

            if (options.Name != null
                || string.IsNullOrWhiteSpace(options.Name))
            {
                product.Name = options.Name;
            }

            if (options.Price > 0)
            {
                product.Price = options.Price;
            }

            if (options.Category == 0)
            {
                product.Category = options.Category;
            }

            context.Set<Product>().Add(product);
            context.SaveChanges();
            return product;
        }

        public int SumOfStocks()
        {
            var sumOfStocks = context
                .Set<Product>()
                .AsQueryable()
                .Sum(c => c.InStock);

            return sumOfStocks;

        }
    }
}
