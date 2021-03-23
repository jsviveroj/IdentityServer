using System.Threading.Tasks;

namespace IdentityServerApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<object> GetClientsToken(string clientId, string secret);
    }
}
