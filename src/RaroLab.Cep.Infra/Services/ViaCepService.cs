using RaroLab.Cep.Domain.Interfaces;
using RaroLab.Cep.Domain.Models.Services.ViaCep;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RaroLab.Cep.Infra.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepAddressResponseModel> GetAddressAsync(string zipCode)
        {
            var response = await _httpClient.GetAsync($"{zipCode}/json/");
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ViaCepAddressResponseModel>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
