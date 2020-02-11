using System;
using TinyCrm.Core.Data;
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

            var options = new CreateCustomerOptions()
            {
                Email = "dd@codehub.com",
                FirstName = "Dimitris",
                VatNumber = 1234567889
            };

            var customer = customerService.Create(options);

            Assert.NotNull(customer);
            Assert.Equal(options.Email, customer.Email);
            Assert.Equal(options.VatNumber, customer.VatNumber);
            Assert.Equal(options.FirstName, customer.FirstName);
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
