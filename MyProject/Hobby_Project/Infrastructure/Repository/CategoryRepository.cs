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
            HobbyCategory hobbyCategory = await FindById(id); 

            return  _context.HobbyCategories
                .Include(x=>x.HobbySubCategories)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<HobbyCategory> Update(HobbyCategory hobbyCategory)
        {
             await FindById(hobbyCategory.Id);
             _context.ChangeTracker.Clear();
             _context.Update(hobbyCategory);
             return hobbyCategory;
        } 

        public async Task<HobbyCategory> FindById(int id)
        {
           var hobbyCategory =  await _context.HobbyCategories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (hobbyCategory == null) throw new NullReferenceException("Category is null!");

            return hobbyCategory;
        }

    }
}
