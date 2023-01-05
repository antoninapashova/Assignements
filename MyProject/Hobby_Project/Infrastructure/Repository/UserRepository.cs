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

        public async Task DeleteAsync(int id)
        {
            User userForDeliting = await FindById(id);
            _context.Users.Remove(userForDeliting);
        }

        public async Task<IEnumerable<User>> GetAllEntitiesAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await FindById(id);
            return user;
        }

        public async Task<User> Update(User entity)
        {
            User userForUpdating = await FindById(entity.Id);

            _context.Users.Update(userForUpdating);
            return userForUpdating;
        }

        public async Task<User> FindById(int id)
        {
             var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

             if (user == null) throw new NullReferenceException("User with Id: " + id + " does not exist");

            return user;
        }
    }
}
