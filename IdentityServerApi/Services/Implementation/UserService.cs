using AutoMapper;
using IdentityServerApi.Dtos;
using IdentityServerApi.Models;
using IdentityServerApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerApi.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<object> CreateUser(UserDto user)
        {
            User userEntity = _mapper.Map<User>(user);

            var result = await _userManager.CreateAsync(userEntity, user.Password);

            if (result.Succeeded)
            {
                if (await _roleManager.FindByNameAsync(user.Role) == null)
                    await _roleManager.CreateAsync(new IdentityRole(user.Role));

                await _userManager.AddToRoleAsync(userEntity, user.Role);
                await _userManager.AddClaimAsync(userEntity, new Claim("email", userEntity.Email));
                await _userManager.AddClaimAsync(userEntity, new Claim("role", user.Role));
            }
            return user.UserName;
        }
    }
}
