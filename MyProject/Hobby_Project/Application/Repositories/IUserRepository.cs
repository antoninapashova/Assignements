using Application.Repositories;
using Hobby_Project;
using HobbyProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        public Task<UserEntity> FindByUsername(string username);
        public Task<bool> CheckUsernameExists(string username);
        public Task<bool> CheckEmailExists(string email);
    }
}
