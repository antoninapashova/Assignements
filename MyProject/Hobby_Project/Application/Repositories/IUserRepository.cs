using Application.Repositories;
using HobbyProject.Domain.Entity;

namespace HobbyProject.Application.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByUsername(string username);
        Task<UserEntity> FindByEmail(string email);
        Task<bool> CheckUsernameExists(string username);
        Task<bool> CheckEmailExists(string email);
    }
}
