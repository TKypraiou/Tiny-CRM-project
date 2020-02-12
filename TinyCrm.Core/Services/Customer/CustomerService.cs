using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context;
        public CustomerService(TinyCrmDbContext dbContext)
        {
            context = dbContext;
        }

        public List<Customer> Search(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context
                .Set<Customer>()
                .AsQueryable();

            if (options.Id != null)
            {
                query = query.Where(
                    c => c.Id == options.Id);
            }

            if (options.VatNumber != 0)
            {
                query = query.Where(
                    c => c.VatNumber == options.VatNumber);
            }

            if (options.Email != null)
            {
                query = query.Where(
                    c => c.Email == options.Email);
            }

            if (options.LastName != null)
            {
                query = query.Where(c => c.LastName.Contains(options.LastName));
            }

            if (options.FirstName != null)
            {
                query = query.Where(c => c.FirstName.Contains(options.FirstName));
            }

            return query.ToList();
        }

        public List<Customer> SearchById(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var result = Search(options);
            return result.ToList();
        }

        public Customer Create(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Email)
                || options.VatNumber == 0)
            {
                return null;
            }

            var customer = new Customer();

            if (!options.Email.Contains("@"))
            {
                return null;
            }

            customer.FirstName = options.FirstName;
            customer.LastName = options.LastName;
            customer.VatNumber = options.VatNumber;
            customer.Phone = options.Phone;
            customer.Email = options.Email;
            customer.Age = options.Age;

            context.Set<Customer>().Add(customer);
            context.SaveChanges();
            return customer;

        }
    }
}
