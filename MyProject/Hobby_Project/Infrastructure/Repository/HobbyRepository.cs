using Application.Repositories;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class HobbyRepository : IHobbyArticleRepository
    {
        private readonly HobbyDbContext _context;

        public HobbyRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<HobbyEntity> Add(HobbyEntity entity)
        {
             _context.HobbyEntities.Attach(entity).State = EntityState.Added;
             return entity;
        }

        public void Delete(HobbyEntity hobbyEntity)
        {
            _context.HobbyEntities.Remove(hobbyEntity);
        }

        public IEnumerable<HobbyEntity> GetHobbyArticlesByUserId(int id)
        {
            return _context.HobbyEntities
                .Include(x => x.User)
                .Include(h => h.HobbyPhoto)
                .AsQueryable()
                .Where(h=>h.User.Id==id);
        }
        
        public IEnumerable<HobbyEntity> GetAllEntities()
        {
            return _context.HobbyEntities
                .Include(x => x.User)
                .Include(x => x.HobbyPhoto);
        }

        public async Task<HobbyEntity> GetByIdAsync(int id)
        {
           await GetById(id);

            return await _context.HobbyEntities
                    .Include(h => h.HobbyPhoto)
                    .SingleAsync(x => x.Id == id);
        }
      
        public HobbyEntity Update(HobbyEntity hobbyArticle)
        {
            _context.HobbyEntities.Update(hobbyArticle);
            return hobbyArticle;
        }
        
        public IEnumerable<HobbyEntity> GetHobbyArticlesByUsername(string username)
        {
            return _context.HobbyEntities
                     .Include(h => h.HobbyPhoto)
                     .AsQueryable() 
                     .Where(h => h.User.Username.Equals(username));
        }

        public async Task<HobbyEntity> GetById(int id)
        {
            return await _context.HobbyEntities.FirstOrDefaultAsync(h => h.Id == id);
        }

        public Task<bool> FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
