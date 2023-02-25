using HobbyProject.Application.Repositories;
using HobbyProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        public Task<UserEntity> Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
