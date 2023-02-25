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

        public async Task<SubCategory> Add(SubCategory entity)
        {
            await _context.SubCategories.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
             SubCategory hobbySubCategory = await FindById(id);
             _context.SubCategories.Remove(hobbySubCategory);
        }

        public async Task<IEnumerable<SubCategory>> GetAllEntitiesAsync()
        {
            return  _context.SubCategories.AsEnumerable();
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            SubCategory hobbySubCategory = await FindById(id);
            return hobbySubCategory;
        }

        public async Task<SubCategory> Update(SubCategory hobbySubCategory)
        {
            SubCategory subCategoryForEditing = await FindById(hobbySubCategory.Id);

            _context.Update(subCategoryForEditing);
            return hobbySubCategory;
        }
        
        public async Task<SubCategory> FindById(int id)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(s => s.Id == id);

            if (subCategory == null) throw new NullReferenceException("SubCategory with Id: " + id + " does not exist");

            return subCategory;
        }

    }
}
