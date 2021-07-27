using AutoMapper;
using Moq;
using RaroLab.Cep.API.Services;
using RaroLab.Cep.API.ViewModels;
using RaroLab.Cep.Domain.Interfaces;
using RaroLab.Cep.Unit.Tests.Mocks.Customer;
using RaroLab.Cep.Unit.Tests.Mocks.Services;
using System.Threading.Tasks;
using Xunit;

namespace RaroLab.Cep.Unit.Tests.Services
{
    public class CustomerServiceTest
    {
        private readonly Mock<IViaCepService> _viaCepMock;
        private readonly Mock<IMapper> _mapperMock;

        public CustomerServiceTest()
        {
            _viaCepMock = new Mock<IViaCepService>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAddressByZipCodeAsync_ReturnCustomerAddressResponseViewModelTestAsync()
        {
            var zipCode = AddressResponseViewModelMock.ZipCodeUnformatedFaker.Generate();
            var viaCepResponseMock = ViaCepAddressResponseModelMock.ViaCepAddressResponseModelFaker.Generate();
            var addressResponseViewModelMock = AddressResponseViewModelMock.AddressResponseViewModelFaker.Generate();

            _viaCepMock.Setup(x => x.GetAddressAsync(zipCode))
                .ReturnsAsync(viaCepResponseMock);

            _mapperMock.Setup(x => x.Map<AddressResponseViewModel>(viaCepResponseMock))
                .Returns(addressResponseViewModelMock);

            var customerService = new AddressService(_viaCepMock.Object, _mapperMock.Object);
            var method = await customerService.GetAddressByZipCodeAsync(zipCode);
            Assert.IsAssignableFrom<AddressResponseViewModel>(method);
        }
    }
}
