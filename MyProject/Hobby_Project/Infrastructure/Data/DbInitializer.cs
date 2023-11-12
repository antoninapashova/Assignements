using HobbyProject.Application.Helpers;
using HobbyProject.Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                InitAdmin(context);
            }
        }

        private static void InitAdmin(HobbyDbContext context)
        {
            var user = new UserEntity 
            { 
                Username = "Admin", 
                FirstName = "Antonina", 
                LastName = "Pashova", 
                Email = "antoninapasova95@gmail.com", 
                Role = "Admin",
                Password = PasswordHasher.HashPassword("123456"),
                Token = "",
                RefreshToken = ""
            };

            context.Users.Add(user);
            context.SaveChanges();  
        }
    }
}
