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

namespace Infrastructure
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
            _context.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            User user =await isValid(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllEntitiesAsync()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user =await isValid(id);
            return user;
        }

        public Task UpdateAsync(int id, User entity)
        {
            throw new NotImplementedException();
        }

        private async Task<User> isValid(int Id)
        {
            if (Id <= 0) throw new NullReferenceException("Id must be positive!");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null) throw new InvalidOperationException("User with ID: " + Id + "does not exist");
            return user;
        }
    }
}
