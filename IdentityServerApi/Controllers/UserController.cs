using IdentityServerApi.Dtos;
using IdentityServerApi.Services.Interfaces;
using IdentityServerApi.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServerApi.Controllers
{
    [Produces(Routes.ProducesJson)]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Routes.UserController.CreateUser)]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
            =>Ok(await _userService.CreateUser(user));
    }
}
