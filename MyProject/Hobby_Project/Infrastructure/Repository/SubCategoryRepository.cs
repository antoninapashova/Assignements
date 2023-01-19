using Application.Repositories;
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
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
             HobbySubCategory hobbySubCategory = await FindById(id);
             _context.HobbySubCategories.Remove(hobbySubCategory);
        }

        public async Task<IEnumerable<HobbySubCategory>> GetAllEntitiesAsync()
        {
            return  _context.HobbySubCategories.AsEnumerable();
        }

        public async Task<HobbySubCategory> GetByIdAsync(int id)
        {
            HobbySubCategory hobbySubCategory = await FindById(id);
            return hobbySubCategory;
        }

        public async Task<HobbySubCategory> Update(HobbySubCategory hobbySubCategory)
        {
            HobbySubCategory subCategoryForEditing = await FindById(hobbySubCategory.Id);

            _context.Update(subCategoryForEditing);
            return hobbySubCategory;
        }
        
        public async Task<HobbySubCategory> FindById(int id)
        {
            var subCategory = await _context.HobbySubCategories.FirstOrDefaultAsync(s => s.Id == id);

            if (subCategory == null) throw new NullReferenceException("SubCategory with Id: " + id + " does not exist");

            return subCategory;
        }

    }
}
