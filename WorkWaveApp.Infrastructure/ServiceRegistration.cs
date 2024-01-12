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















            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=WorkWaveApp;"));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer("Data Source=DESKTOP-9RG21DM\\SQLEXPRESS;Initial Catalog=WorkWaveDb;Integrated Security=true;TrustServerCertificate=true"));

        }
    }
}
