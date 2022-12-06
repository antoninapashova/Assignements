using Application.Repositories;
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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly HobbyDbContext _context;

        public SubCategoryRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<HobbySubCategory> Add(HobbySubCategory entity)
        {
            await _context.HobbySubCategories.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            HobbySubCategory subCategory = await isValid(id);
             _context.HobbySubCategories.Remove(subCategory);
            _context.SaveChanges();

        }
        public async Task<IEnumerable<HobbySubCategory>> GetAllEntitiesAsync()
        {
            return await _context.HobbySubCategories.ToListAsync();
        }

       public async Task<HobbySubCategory> GetByIdAsync(int id)
        {
            HobbySubCategory subCategory = await isValid(id);
            return subCategory;
        }
        public async Task UpdateAsync(int id, HobbySubCategory hobbySubCategory)
        {
            HobbySubCategory subCategory =await isValid(id);
            //Refactor
            
        }

        private async Task<HobbySubCategory> isValid(int Id)
        {
            if (Id <= 0) throw new NullReferenceException("Id must be positive");
            var subCategory = await _context.HobbySubCategories.FirstOrDefaultAsync(s => s.Id == Id);
            if (subCategory == null) throw new InvalidOperationException("SubCategory with Id: " + Id + "does not exist");
            return subCategory;
        }
    }
}
