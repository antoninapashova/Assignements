using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyProject.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Run(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<HobbyDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
