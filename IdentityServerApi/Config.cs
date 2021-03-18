using Duende.IdentityServer.Models;
using IdentityServerApi.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServerApi
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("identityApi", "Identity Server API")
            };

        public static IEnumerable<Client> Clients 
        {
            get
            {
                var clients = Startup.StaticConfig
                    .GetSection($"IdentityServer:SecurityClients")
                    .Get<SecurityClient[]>();

                return clients?.Select(m => new Client()
                {
                    ClientId = m.ClientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = m.ClientSecrets?.Select(o => new Secret(o.Sha256())).ToArray(),
                    AccessTokenLifetime = int.Parse(Startup.StaticConfig.GetSection("IdentityServer:AccessTokenLifetime").Value),
                    AllowedScopes = m.Scopes,
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    UpdateAccessTokenClaimsOnRefresh = true
                }).ToList();
            }
        }
    }
}