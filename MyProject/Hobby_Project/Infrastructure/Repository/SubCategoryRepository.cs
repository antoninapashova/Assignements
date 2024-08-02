using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(SubCategory subCategory)
        {
             _context.SubCategories.Remove(subCategory);
        }

        public IEnumerable<SubCategory> GetAllEntities()
        {
            return _context.SubCategories.AsEnumerable();
        }

        public async Task<SubCategory> GetByIdAsync(int id)
        {
            return await FindById(id);
        }

        public async Task<bool> CheckSubCategoryExists(string name)
        {
           return await _context.SubCategories.AnyAsync(s => s.Name == name);
        }

        public async Task<SubCategory> FindById(int id)
        {
            return await _context.SubCategories.FirstOrDefaultAsync(s => s.Id == id);
        }

        public SubCategory Update(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<SubCategory>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
