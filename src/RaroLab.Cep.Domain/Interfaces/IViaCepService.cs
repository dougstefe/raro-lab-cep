using RaroLab.Cep.Domain.Models.Services.ViaCep;
using System.Threading.Tasks;

namespace RaroLab.Cep.Domain.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepAddressResponseModel> GetAddressAsync(string zipCode);
    }
}
