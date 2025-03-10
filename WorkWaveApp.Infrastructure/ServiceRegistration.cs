﻿using WorkWaveApp.Application.CQRS.Account.Command.Login;
using WorkWaveApp.Application.CQRS.Account.Command.Register;
using WorkWaveApp.Application.CQRS.Account.Command.Vacancy;
using WorkWaveApp.Application.CQRS.Vacancies.Query;

namespace WorkWaveApp.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Code below and the one with IConfiguration both works for getting ConnectionString

            //ConfigurationManager configurationManager = new();
            //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WorkWaveApp.API"));
            //configurationManager.AddJsonFile("appsettings.json");


            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();



            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IVacancyService, VacancyService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddVacancyCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllVacanciesQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetVacancyByIdQueryHandler).Assembly));

            services.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommandValidator).Assembly));
            services.AddScoped<ICacheService, CacheService>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "WorkWave_Redis";
            });



            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(configurationManager["Database:Connection"]));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration["Database:Connection"]));

        }
    }
}
