using Application.Repositories;
using HobbyProject.Application.Repositories;
using HobbyProject.Infrastructure.Repository;
using Infrastructure.Repository;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyProject.Infrastructure.Configurations
{
    public static class RepositoryConfigurations
    {
        public static void AddRepositoryConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IHobbyArticleRepository, HobbyRepository>();
            services.AddScoped<IPhotoRepository, HobbyPhotoRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();
        }
    }
}
