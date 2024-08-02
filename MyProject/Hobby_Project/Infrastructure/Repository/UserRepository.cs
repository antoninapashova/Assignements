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

        public IEnumerable<UserEntity> GetAllEntities()
        {
            return _context.Users;
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<UserEntity> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Username == username);
        }

        public UserEntity Update(UserEntity entity)
        {
            _context.ChangeTracker.Clear();
            _context.Update(entity);
            return entity;
        }

        public async Task<bool> CheckUsernameExists(string username)
        {
            return await _context.Users.AsNoTracking().AnyAsync(x => x.Username == username);
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _context.Users.AsNoTracking().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> FindById(int id)
        {
           return await _context.Users.AsNoTracking().AnyAsync(c => c.Id == id);
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
