using System;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
using Xunit;

namespace TinyCrmTests
{
    public class CustomerServiceTests
    {
        private TinyCrmDbContext context_;
        public CustomerServiceTests()
        {
            context_ = new TinyCrmDbContext();
        }

        [Fact]
        public void CreateCustomer_Success()
        {
            ICustomerService customerService =
                new CustomerService(context_);

            var optionsCreate = new CreateCustomerOptions()
            {
                Email = "tk@codehub.com",
                FirstName = "dora",
                VatNumber = 0987654321
            };

            var customer = customerService.Create(optionsCreate);

            var optionsSearch = new SearchCustomerOptions()
            {
                Email = optionsCreate.Email,
                FirstName = optionsCreate.FirstName,
                VatNumber = optionsCreate.VatNumber
                
            };

            var customers = customerService.Search(optionsSearch);
            
            Assert.NotNull(customer);
            Assert.Equal(optionsSearch.Email, customer.Email);
            Assert.Equal(optionsSearch.VatNumber, customer.VatNumber);
            Assert.Equal(optionsSearch.FirstName, customer.FirstName);
            Assert.NotEqual(0, customer.Id);

        }

        [Fact]
        public void CreateCustomer_Fail_Null_VatNumber()
        {
            ICustomerService customerService =
                new CustomerService(context_);

            var options = new CreateCustomerOptions()
            {
                Email = "dd@codehub.com",
                FirstName = "Dimitris",
                VatNumber = 0
            };

            var customer = customerService.Create(options);
            Assert.Null(customer);
        }

        [Fact]
        public void CreateCustomer_Fail_Null_Email()
        {
            ICustomerService customerService = new CustomerService(context_);

            var options = new CreateCustomerOptions() 
            {
                Email = "",
                FirstName = "Dimitris",
                VatNumber = 0
            };

            var customer = customerService.Create(options);
            Assert.Null(customer);

        }
    }
}
