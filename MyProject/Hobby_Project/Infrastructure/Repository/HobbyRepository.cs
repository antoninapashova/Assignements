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

        public async Task<HobbyArticle> Add(HobbyArticle entity)
        {
            await _context.HobbyArticles.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            HobbyArticle articleForDeleting = await FindById(id);

            _context.HobbyArticles.Remove(articleForDeleting);
        }

       

        public async Task<IEnumerable<HobbyArticle>> GetAllEntitiesAsync()
        {
            return await _context.HobbyArticles
                .Include(x=>x.HobbyComments)
                   .ThenInclude(hc=>hc.User)
                .Include(x => x.HobbySubCategory)
                .Include(x => x.HobbyPhoto)
                .Include(x => x.Tags)
                .Include(x => x.User)
                .ToListAsync();
        }
        public async Task<HobbyArticle> GetByIdAsync(int id)
        {
           await FindById(id);
            
            return await _context.HobbyArticles
                    .Where(h => h.Id == id)
                    .Include(h => h.HobbySubCategory)
                    .Include(h => h.User)
                    .Include(h=>h.Tags)
                    .FirstOrDefaultAsync();
        }
      
        public async Task<HobbyArticle> Update(HobbyArticle hobbyArticle)
        {
            _context.HobbyArticles.Update(hobbyArticle);
            return hobbyArticle;
        }

        public async Task<HobbyArticle> FindById(int id)
        {
            var hobby = await _context.HobbyArticles.FirstOrDefaultAsync(h => h.Id == id);

            if (hobby == null) throw new NullReferenceException("HobbyArticle with Id: " + id + " does not exist");
            return hobby;
        }
    }
}
