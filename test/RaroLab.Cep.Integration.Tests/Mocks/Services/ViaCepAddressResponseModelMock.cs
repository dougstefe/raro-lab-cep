using Bogus;
using RaroLab.Cep.Domain.Models.Services.ViaCep;

namespace RaroLab.Cep.Integration.Tests.Mocks.Services
{
    public static class ViaCepAddressResponseModelMock
    {
        public static Faker<ViaCepAddressResponseModel> ViaCepAddressResponseModelFaker =>
            new Faker<ViaCepAddressResponseModel>()
            .CustomInstantiator(x => new ViaCepAddressResponseModel {
                Cep = x.Address.ZipCode("#####-###"),
                Logradouro = x.Address.StreetAddress(false),
                Complemento = x.Random.Words(3),
                Bairro = x.Address.City(),
                Localidade = x.Address.State(),
                Uf = x.Address.StateAbbr(),
                Ibge = x.Random.Number(232323, 999999).ToString(),
                Gia = x.Random.Number(1000, 9999).ToString(),
                Ddd = x.Random.Number(10, 99).ToString(),
                Siafi = x.Random.Number(1000, 9999).ToString()
            });
        public static Faker<string> ZipCodeUnformatedFaker => new Faker<string>().CustomInstantiator(x => x.Address.ZipCode("########"));

    }
}
