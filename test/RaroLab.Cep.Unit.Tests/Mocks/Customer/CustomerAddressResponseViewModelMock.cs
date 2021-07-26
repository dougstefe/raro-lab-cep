using Bogus;
using RaroLab.Cep.API.ViewModels;

namespace RaroLab.Cep.Unit.Tests.Mocks.Customer
{
    public class CustomerAddressResponseViewModelMock
    {
        public static Faker<CustomerAddressResponseViewModel> CustomerAddressResponseViewModelFaker =>
            new Faker<CustomerAddressResponseViewModel>()
            .CustomInstantiator(x => new CustomerAddressResponseViewModel
            {
                ZipCode = ZipCodeFormatedFaker,
                Address = x.Address.StreetAddress(false),
                Complement = x.Random.Words(3),
                District = x.Address.City(),
                Location = x.Address.State(),
                FU = x.Address.StateAbbr()
            });

        public static Faker<string> ZipCodeFormatedFaker => new Faker<string>().CustomInstantiator(x => x.Address.ZipCode("#####-###"));
        public static Faker<string> ZipCodeUnformatedFaker => new Faker<string>().CustomInstantiator(x => x.Address.ZipCode("########"));
    }
}
