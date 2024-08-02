using Application.Repositories;
using HobbyProject.Domain.Entity;

namespace HobbyProject.Application.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetByUsername(string username);
        Task<bool> CheckUsernameExists(string username);
        Task<bool> CheckEmailExists(string email);
        Task<UserEntity> GetByEmail(string email);
    }
}
