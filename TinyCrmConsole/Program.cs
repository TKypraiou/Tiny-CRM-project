using System;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Product1;

namespace TinyCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext()) 
            {
                ICustomerService customerService = new CustomerService(context);
                IProductService productService = new ProductService(context);

                //context.Add(
                //new Product
                //{
                //    Name = "iPhone",
                //    Price = 1000,
                //    InStock = 100,
                //    Id = "123",
                //    Category = ProductCategory.Smartphones
                //});

                //context.Add(
                //    new Product
                //    {
                //        Name = "Nikon",
                //        Price = 599,
                //        InStock = 74,
                //        Id = "345",
                //        Category = ProductCategory.Cameras
                //    });
                //context.SaveChanges();

                //var sum = productService.SumOfStocks();

                //var options = new SearchCustomerOptions
                //{
                //    VatNumber = 123456789
                //};
                

                var customer = new Customer()
                {};

                context.Set<Customer>().Add(customer);
                context.SaveChanges();
                //return customer;
                //var results = customerService.Create(Customer);

                //var options = new SearchCustomerOptions
                //{
                //    FirstName = "itr"
                //};
            }

        }
    }
}
