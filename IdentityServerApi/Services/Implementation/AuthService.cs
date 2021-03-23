using IdentityModel.Client;
using IdentityServerApi.Services.Interfaces;
using IdentityServerApi.Utility;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServerApi.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<object> GetClientsToken(string clientId, string secret)
        {
            var client = _clientFactory.CreateClient(Routes.Clients.ClientCredentialsClient);
            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = client.BaseAddress.AbsoluteUri,
                ClientId = clientId,
                ClientSecret = secret,
                Scope = Routes.Scopes.UsersApiScope
            });

            if (response.Error == null)
                return new { Token = response.AccessToken, ExpirationTime = response.ExpiresIn };
            else
                return new { response.Error };
        }
    }
}
