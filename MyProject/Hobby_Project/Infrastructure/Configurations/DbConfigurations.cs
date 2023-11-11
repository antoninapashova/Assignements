using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyProject.Infrastructure.Configurations
{
    public static class DbConfigurations
    {
        public static void AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HobbyDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<HobbyDbContext>();
        }
    }
}
