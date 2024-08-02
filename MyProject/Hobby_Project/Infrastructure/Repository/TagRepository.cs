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

        public async Task<IEnumerable<Tag>> GetAllEntitiesAsync()
        {
            return _context.Tags.AsNoTracking().AsQueryable();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
           return await FindById(id);
        } 
        
        public async Task<bool> CheckTagExists(string name)
        {
            return await _context.Tags.AnyAsync(t => t.Name == name);
        }

        public async Task<Tag> FindById(int id)
        {
            var tag = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

            if (tag == null) 
                throw new NullReferenceException($"Tag with Id {id} does not exist!");

            return tag;
        }

        public Task<Tag> Update(Tag entity)
        {
            throw new NotImplementedException();
        }
    }
}
