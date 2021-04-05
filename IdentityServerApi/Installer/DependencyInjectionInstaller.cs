using IdentityServerApi.Models;
using IdentityServerApi.Services.Implementation;
using IdentityServerApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerApi.Installer
{
    public class DependencyInjectionInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();     
        }
    }
}
