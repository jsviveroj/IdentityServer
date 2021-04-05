﻿using FluentValidation.AspNetCore;
using IdentityServerApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerApi.Installer
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddCors();
            services.AddDbContext<IdentityServerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
