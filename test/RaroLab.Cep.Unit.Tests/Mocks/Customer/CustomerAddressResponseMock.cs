using Bogus;
using RaroLab.Cep.Domain.Models.Customer;

namespace RaroLab.Cep.Unit.Tests.Mocks.Customer
{
    public static class CustomerAddressResponseMock
    {
        public static Faker<CustomerAddressResponseModel> CustomerAddressResponseModelFaker =>
            new Faker<CustomerAddressResponseModel>()
            .CustomInstantiator(x => new CustomerAddressResponseModel {
                ZipCode = x.Address.ZipCode("#####-###"),
                Address = x.Address.StreetAddress(false),
                Complement = x.Random.Words(3),
                District = x.Address.City(),
                Location = x.Address.State(),
                FU = x.Address.StateAbbr()
            });
    }
}
