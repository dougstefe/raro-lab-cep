using Microsoft.AspNetCore.Mvc;
using RaroLab.Cep.API.Services.Interfaces;
using RaroLab.Cep.API.ViewModels;
using System.Threading.Tasks;

namespace RaroLab.Cep.API.Controllers.v1
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/address")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("zip-code/{zipCode}")]
        public async Task<ActionResult<AddressResponseViewModel>> GetAddressByZipCode([FromRoute] AddressRequestViewModel request)
        {
            var response = await _addressService.GetAddressByZipCodeAsync(request.ZipCode);
            if(response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
