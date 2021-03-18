using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerApi.Installer
{
    public class IdentityServerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryPersistedGrants()
            .AddInMemoryApiResources(Config.Apis)
            .AddInMemoryClients(Config.Clients);
        }
    }
}
