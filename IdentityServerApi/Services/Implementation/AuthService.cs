using IdentityModel.Client;
using IdentityServerApi.Dtos;
using IdentityServerApi.Models;
using IdentityServerApi.Services.Interfaces;
using IdentityServerApi.Utility;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServerApi.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly SignInManager<User> _signInManager;

        public AuthService(IHttpClientFactory clientFactory,
            SignInManager<User> signInManager)
        {
            _clientFactory = clientFactory;
            _signInManager = signInManager;
        }

        public async Task<object> GetClientsToken(string clientId, string secret)
        {
            var client = _clientFactory.CreateClient(Routes.Clients.ClientCredentialsClient);
            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = client.BaseAddress.AbsoluteUri,
                ClientId = clientId,
                ClientSecret = secret,
                Scope = Routes.Scopes.All
            });

            if (response.Error == null)
                return new { Token = response.AccessToken, ExpirationTime = response.ExpiresIn };
            else
                return new { response.Error };
        }

        public async Task<object> UserLogin(LoginDto userLogin)
        {
            var loquesea = await _signInManager.
                PasswordSignInAsync(userLogin.Username, userLogin.Password, false, false);
            return loquesea;
        }
    }
}
