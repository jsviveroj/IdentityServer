using IdentityServerApi.Dtos;
using System.Threading.Tasks;

namespace IdentityServerApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<object> CreateUser(UserDto user);
    }
}
