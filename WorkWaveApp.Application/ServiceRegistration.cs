
namespace WorkWaveApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddVacancyCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllVacanciesQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetVacancyByIdQueryHandler).Assembly));

            services.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();


            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommandValidator).Assembly));




        }
    }
}
