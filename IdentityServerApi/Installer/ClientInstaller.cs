using IdentityServerApi.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IdentityServerApi.Installer
{
    public class ClientInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(Routes.Clients.ClientCredentialsClient, c =>
                c.BaseAddress = new Uri(configuration.GetSection(Routes.Sections.IdentityServerClientCredentials).Value));
        }
    }
}
