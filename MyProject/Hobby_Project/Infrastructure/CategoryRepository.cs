using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
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
            _context.SaveChanges();
            return entity;
         }

       
        public async Task DeleteAsync(int id)
        {
            HobbyCategory hobbyCategory = await isValid(id);
            _context.Remove(hobbyCategory);
            _context.SaveChanges();
        }
        

        public async Task<IEnumerable<HobbyCategory>> GetAllEntitiesAsync()
        {
            return await _context.HobbyCategories
                  .Include(h => h.HobbySubCategories)
                  .ThenInclude(s => s.Name)
                  .ToListAsync();
        }
        
        public async Task<HobbyCategory> GetByIdAsync(int id)
        {
            var hobbyCategory = await isValid(id);
            return hobbyCategory;
        }

        public async Task UpdateAsync(int id, HobbyCategory hobbyCategory)
        {
           var category= await isValid(id);
            _context.HobbyCategories.Update(category);
            //Refactor 
            _context.SaveChanges();
        }

        private async Task<HobbyCategory> isValid(int id)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive");
            var hobbyCategories = _context.HobbyCategories;
            var category = await hobbyCategories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");
            return category;
        }
       
    }
}
