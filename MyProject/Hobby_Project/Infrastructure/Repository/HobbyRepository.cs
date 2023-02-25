using Application.Repositories;
using Domain.Entity;
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

        public async Task DeleteAsync(int id)
        {
            HobbyEntity articleForDeleting = await FindById(id);

            _context.HobbyEntities.Remove(articleForDeleting);
        }

        
        public async Task<IEnumerable<HobbyEntity>> GetHobbyArticlesByUserId(int id)
        {
            return await _context.HobbyEntities
                .Include(h => h.HobbySubCategory)
                .Include(h => h.HobbyComments)
                .Include(h => h.Tags)
                .Include(h=>h.HobbyPhoto)
                .ToListAsync();
        }
        

        public async Task<IEnumerable<HobbyEntity>> GetAllEntitiesAsync()
        {
            return await _context.HobbyEntities
                .Include(x=>x.HobbyComments)
                .Include(x => x.HobbySubCategory)
                .Include(x => x.HobbyPhoto)
                .Include(x => x.Tags)
                .ToListAsync();
        }
        public async Task<HobbyEntity> GetByIdAsync(int id)
        {
           await FindById(id);
            
            return await _context.HobbyEntities
                    .Where(h => h.Id == id)
                    .Include(h => h.HobbySubCategory)
                    .Include(h=>h.Tags)
                    .Include(h => h.HobbyPhoto)
                    .FirstOrDefaultAsync();
        }
      
        public async Task<HobbyEntity> Update(HobbyEntity hobbyArticle)
        {
            _context.HobbyEntities.Update(hobbyArticle);
            return hobbyArticle;
        }
        
        public async Task<IEnumerable<HobbyEntity>> GetHobbyArticlesByUsername(string username)
        {
            return await _context.HobbyEntities
                     //.Where(h => h.Username.Equals(username))
                     .Include(h => h.HobbySubCategory)
                     .Include(h => h.Tags)
                     .Include(h => h.HobbyPhoto)
                     .ToListAsync();
        }

        public async Task<HobbyEntity> FindById(int id)
        {
            var hobby = await _context.HobbyEntities.FirstOrDefaultAsync(h => h.Id == id);

            if (hobby == null) throw new NullReferenceException("HobbyArticle with Id: " + id + " does not exist");
            return hobby;
        }

        
    }
}
