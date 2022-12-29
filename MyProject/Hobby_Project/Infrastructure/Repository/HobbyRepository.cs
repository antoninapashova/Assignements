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
            var hobbyArt = await isValid(id);
            _context.HobbyArticles.Remove(hobbyArt);
        }
        public async Task<IEnumerable<HobbyArticle>> GetAllEntitiesAsync()
        {
            return await _context.HobbyArticles
                .Include(x=>x.HobbyComments)
                   .ThenInclude(x=>x.User)
                .Include(x=>x.HobbySubCategory)
                .Include(x=>x.HobbyPhoto)
                .Include(x=>x.Tags)
                
                .Include(x=>x.User)
                .ToListAsync();
        }
        public async Task<HobbyArticle> GetByIdAsync(int id)
        {
           var hobbyArticle = await isValid(id);
            return await _context.HobbyArticles
                    .Where(h => h.Id == id)
                    .Include(x => x.HobbySubCategory)
                    .Include(y => y.User)
                    .Include(z=>z.Tags)
                    
                    .FirstOrDefaultAsync();
        }

        public async Task<HobbyArticle> Update(HobbyArticle hobbyArticle)
        {
            _context.HobbyArticles.Update(hobbyArticle);
            return hobbyArticle;
        }

        private async Task<HobbyArticle> isValid(int Id)
        {
            if (Id <= 0) throw new ArgumentException("Id must be positive");
            var hobby = await _context.HobbyArticles.FirstOrDefaultAsync(h => h.Id == Id);
            
            if (hobby == null) throw new InvalidOperationException("HobbyArticle with Id: " + Id + " does not exist");
            return hobby;
        }
    }
}
