using IdentityServerApi.Services.Interfaces;
using IdentityServerApi.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServerApi.Controllers
{
    [Produces(Routes.ProducesJson)]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpGet(Routes.AuthController.GetClientToken)]
        public async Task<IActionResult> ClientLogin(string clientId, string clientSecret)
        {
            var response = await _service.GetClientsToken(clientId, clientSecret);
            return Ok(response);
        }
    }
}
