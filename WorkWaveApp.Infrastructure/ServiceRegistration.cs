﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorkWaveApp.Application.CQRS.Account.Command.Login;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Infrastructure.Services;


namespace WorkWaveApp.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly));










            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=.;Initial Catalog=WorkWaveDb;Integrated Security=true;TrustServerCertificate=true"));

        }
    }
}
