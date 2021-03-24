using Duende.IdentityServer.Models;
using IdentityServerApi.Models;
using IdentityServerApi.Utility;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServerApi
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
                {
                    new ApiScope(name: Routes.Scopes.All,   displayName: "Perform all actions to your data."),
                    new ApiScope(name: Routes.Scopes.Read,   displayName: "Read your data."),
                    new ApiScope(name: Routes.Scopes.Write,  displayName: "Write your data."),
                    new ApiScope(name: Routes.Scopes.Delete, displayName: "Delete your data.")
                };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource(Routes.Apiresources.UsersApi, "Users API")
                {
                    Scopes = { Routes.Scopes.All }
                }
            };

        public static IEnumerable<Client> Clients 
        {
            get
            {
                var clients = Startup.StaticConfig
                    .GetSection(Routes.Sections.SecurityClients)
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