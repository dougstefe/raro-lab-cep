using RaroLab.Cep.API.ViewModels;
using System.Threading.Tasks;

namespace RaroLab.Cep.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerAddressResponseViewModel> GetAddressByZipCodeAsync(string zipCode);
    }
}
