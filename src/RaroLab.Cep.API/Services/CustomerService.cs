using RaroLab.Cep.API.Services.Interfaces;
using RaroLab.Cep.API.ViewModels;
using System.Threading.Tasks;

namespace RaroLab.Cep.API.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<CustomerAddressResponseViewModel> GetAddressByZipCodeAsync(string zipCode)
        {
            return null;
        }
    }
}
