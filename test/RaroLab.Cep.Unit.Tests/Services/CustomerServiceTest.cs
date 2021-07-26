using RaroLab.Cep.API.Services;
using RaroLab.Cep.API.ViewModels;
using RaroLab.Cep.Unit.Tests.Mocks.Customer;
using System.Threading.Tasks;
using Xunit;

namespace RaroLab.Cep.Unit.Tests.Services
{
    public class CustomerServiceTest
    {

        public CustomerServiceTest()
        {
            
        }

        [Fact]
        public async Task GetAddressByZipCodeAsync_ReturnCustomerAddressResponseViewModelTestAsync()
        {
            var zipCode = CustomerAddressResponseViewModelMock.ZipCodeUnformatedFaker.Generate();
            var customerService = new CustomerService();
            var method = await customerService.GetAddressByZipCodeAsync(zipCode);
            Assert.IsAssignableFrom<CustomerAddressResponseViewModel>(method);
        }
    }
}
