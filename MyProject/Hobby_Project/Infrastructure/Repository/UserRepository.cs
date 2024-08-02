using HobbyProject.Application.Repositories;
using HobbyProject.Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HobbyProject.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HobbyDbContext _context;

        public UserRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> Add(UserEntity entity)
        {
            await _context.Users.AddAsync(entity);
            return entity;
        }

        public void Delete(UserEntity user)
        {
           _context.Remove(user);
        }

        public async Task<IEnumerable<UserEntity>> GetAllEntitiesAsync()
        {
            return _context.Users.AsNoTracking();
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await FindById(id);
        }

        public async Task<UserEntity> Update(UserEntity entity)
        {
            await FindById(entity.Id);
            _context.ChangeTracker.Clear();
            _context.Update(entity);
            return entity;
        }

        public async Task<UserEntity> FindByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<UserEntity> FindByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> CheckUsernameExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username);
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<UserEntity> FindById(int id)
        {
           return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
