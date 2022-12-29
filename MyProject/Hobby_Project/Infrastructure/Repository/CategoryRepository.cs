using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly HobbyDbContext _context;

        public CategoryRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<HobbyCategory> Add(HobbyCategory entity)
        {
            await _context.HobbyCategories.AddAsync(entity);
            return entity;
        }
        public async Task DeleteAsync(int id)
        {
            await IsValidId(id);
            HobbyCategory hobbyCategory = await FindById(id);
            _context.Remove(hobbyCategory);
        }

        public async Task<IEnumerable<HobbyCategory>> GetAllEntitiesAsync()
        {
            return _context.HobbyCategories
                .Include(h => h.HobbySubCategories)
                .AsEnumerable();
        }

        public async Task<HobbyCategory> GetByIdAsync(int id)
        {
            await IsValidId(id);
            HobbyCategory hobbyCategory = await FindById(id);
            _context.HobbyCategories
                .Where(c=>c.Id == id)
                .Include(c=>c.HobbySubCategories);
            return hobbyCategory;
        }

        public async Task<HobbyCategory> Update(HobbyCategory hobbyCategory)
        {
           await IsValidId(hobbyCategory.Id);
            HobbyCategory categoryForEditing = await FindById(hobbyCategory.Id);
            _context.Update(hobbyCategory);
            return hobbyCategory;
        } 
        public async Task<bool> IsValidId(int id)
        {
            if (id <= 0) 
                throw new NullReferenceException("Id must be positive");

            return await Task.FromResult(true);
        }

        public async Task<HobbyCategory> FindById(int id)
        {
            var category = await _context.HobbyCategories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) 
                throw new NullReferenceException("Category with that id does not exist");

            return category;
        }

    }
}
