using Moq;
using Moq.Protected;
using RaroLab.Cep.Domain.Models.Services.ViaCep;
using RaroLab.Cep.Infra.Services;
using RaroLab.Cep.Integration.Tests.Mocks.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RaroLab.Cep.Integration.Tests.Services
{
    public class ViaCepServiceTest
    {

        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

        public ViaCepServiceTest()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        }

        [Fact]
        public async Task GetAddressAsync_ReturnAddressResponseTestAsync()
        {
            var zipCodeMock = ViaCepAddressResponseModelMock.ZipCodeUnformatedFaker.Generate();
            var httpClientMock = $"https://viacep.com.br/ws/{zipCodeMock}/json/";
            _httpMessageHandlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(ViaCepAddressResponseModelMock.ViaCepAddressResponseModelFaker.Generate()))
                });
            var httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri(httpClientMock)
            };
            var viaCepService = new ViaCepService(httpClient);
            var method = viaCepService.GetAddressAsync(zipCodeMock);
            Assert.IsType<ViaCepAddressResponseModel>(method);
        }
    }
}
