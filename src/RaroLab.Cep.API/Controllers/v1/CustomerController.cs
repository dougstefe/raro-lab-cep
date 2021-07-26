using Microsoft.AspNetCore.Mvc;
using RaroLab.Cep.API.ViewModels;
using System.Threading.Tasks;

namespace RaroLab.Cep.API.Controllers.v1
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/customers")]
    public class CustomerController : Controller
    {
        [HttpGet("zip-code/{zipCode}")]
        public async Task<ActionResult<CustomerAddressResponseViewModel>> GetAddressByZipCode([FromRoute] string zipCode)
        {
            return Ok();
        }
    }
}
