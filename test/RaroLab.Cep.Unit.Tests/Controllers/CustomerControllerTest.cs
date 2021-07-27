using Microsoft.AspNetCore.Http;
using Moq;
using RaroLab.Cep.API.Services.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace RaroLab.Cep.Unit.Tests.Controllers
{
    public class CustomerControllerTest
    {
        private readonly Mock<IAddressService> _customerService;

        public CustomerControllerTest()
        {
            _customerService = new Mock<IAddressService>();
        }

    }
}
