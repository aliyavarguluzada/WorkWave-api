using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorkWaveApp.Application.CQRS.Account.Command.Login;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Application.Interfaces;
using WorkWaveApp.Infrastructure.Data;
using WorkWaveApp.Infrastructure.Services;
using System.Reflection;
using WorkWaveApp.Application.CQRS.Account.Command.Vacancy;
using WorkWaveApp.Application.CQRS.Account.Query.Vacancy;

namespace WorkWaveApp.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IVacancyService, VacancyService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddVacancyCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetVacancyQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllVacanciesQueryHandler).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));








            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=.;Initial Catalog=WorkWaveDb;Integrated Security=true;TrustServerCertificate=true"));

        }
    }
}
