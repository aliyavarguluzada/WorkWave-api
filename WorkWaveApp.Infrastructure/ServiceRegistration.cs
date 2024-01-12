using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkWaveApp.Infrastructure.Data;


namespace WorkWaveApp.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
















            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=.;Initial Catalog=WorkWaveDb;Integrated Security=true;TrustServerCertificate=true"));

        }
    }
}
