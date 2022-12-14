using Application.Repositories;
using Domain.Entity;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly HobbyDbContext _context;

        public UserRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            return entity;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            if (await Task.FromResult(_context.Users.
                SingleOrDefault(x => x.Username == username && x.Password == password)) != null)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteAsync(int id)
        {
            User user = await isValid(id);
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllEntitiesAsync()
        {
            return _context.Users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await isValid(id);
            return user;
        }

        public async Task Update(User entity)
        {
            _context.Update(entity);
        }

        private async Task<User> isValid(int id)
        {
            if (id <= 0) throw new NullReferenceException("Id must be positive!");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) throw new InvalidOperationException("User with ID: " + id + "does not exist");
            return user;
        }
    }
}
