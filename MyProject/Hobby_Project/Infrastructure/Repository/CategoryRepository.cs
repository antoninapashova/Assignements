using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal.Execution;

namespace Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly HobbyDbContext _context;

        public CategoryRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            Category hobbyCategory = await FindById(id);

            _context.Remove(hobbyCategory);
        }

        public async Task<IEnumerable<Category>> GetAllEntitiesAsync()
        {
            return _context.Categories.AsNoTracking().AsEnumerable();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await FindById(id);
        }

        public async Task<Category> Update(Category hobbyCategory)
        {
            await FindById(hobbyCategory.Id);
            _context.ChangeTracker.Clear();
            _context.Update(hobbyCategory);
            return hobbyCategory;
        }
        public async Task<IQueryable<Category>> GetAllNamesAsync() {
            return _context.Categories.AsQueryable();
        }
        public async Task<bool> CheckCategoryExists(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }
        public async Task<Category> FindById(int id)
        {
            var hobbyCategory = await _context.Categories.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (hobbyCategory == null) throw new NullReferenceException("Category is null!");

            return hobbyCategory;
        }

       
    }
}
