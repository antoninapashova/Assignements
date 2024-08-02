using Application.Repositories;
using HobbyProject.Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly HobbyDbContext _context;

        public TagRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Add(Tag entity)
        {
            await _context.Tags.AddAsync(entity);
            return entity;
        }

        public void Delete(Tag entity)
        {
            _context.Tags.Remove(entity);
        }
        
        public IEnumerable<Tag> GetAllEntities()
        {
            return _context.Tags.AsNoTracking();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
           return await _context.Tags.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
        
        public async Task<bool> CheckTagExists(string name)
        {
            return await _context.Tags.AnyAsync(t => t.Name == name);
        }

        public Tag Update(Tag entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<Tag>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
