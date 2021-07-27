using AutoMapper;
using RaroLab.Cep.API.Services.Interfaces;
using RaroLab.Cep.API.ViewModels;
using RaroLab.Cep.Domain.Interfaces;
using System.Threading.Tasks;

namespace RaroLab.Cep.API.Services
{
    public class AddressService : IAddressService
    {
        private readonly IViaCepService _viaCepService;
        private readonly IMapper _mapper;

        public AddressService(IViaCepService viaCepService, IMapper mapper)
        {
            _viaCepService = viaCepService;
            _mapper = mapper;
        }

        public async Task<AddressResponseViewModel> GetAddressByZipCodeAsync(string zipCode)
        {
            var response = await _viaCepService.GetAddressAsync(zipCode);
            if (!response.Erro)
            {
                return _mapper.Map<AddressResponseViewModel>(response);
            }
            return null;
        }
    }
}
