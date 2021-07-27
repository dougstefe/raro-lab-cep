using RaroLab.Cep.API.ViewModels;
using System.Threading.Tasks;

namespace RaroLab.Cep.API.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressResponseViewModel> GetAddressByZipCodeAsync(string zipCode);
    }
}
