using Application.Repositories;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class HobbyPhotoRepository : IPhotoRepository
    {
        private readonly HobbyDbContext _context;

        public HobbyPhotoRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Photo> Add(Photo entity)
        {
           await _context.Photos.AddAsync(entity);
           return entity;
        }

        public async Task<Photo> GetByIdAsync(int id)
        {
            var hobbyPhoto = await FindById(id);
            return  hobbyPhoto;
        }

        public void Delete(Photo entity)
        {
            _context.Photos.Remove(entity);
        }

        public Photo Update(Photo entity)
        {
            _context.Photos.Update(entity);
            return entity;
        }

        public async Task<Photo> FindById(int id)
        {
            return await _context.Photos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Photo> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<Photo>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
