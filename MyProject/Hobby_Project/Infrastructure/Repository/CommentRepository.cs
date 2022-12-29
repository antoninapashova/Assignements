using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly HobbyDbContext _context;

        public CommentRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<HobbyComment> Add(HobbyComment entity)
        {
            await _context.HobbyComments.AddAsync(entity);
           
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
             await IsValidId(id);
            var comment = await FindById(id);
            _context.HobbyComments.Remove(comment);
            
        }

        public async Task<IEnumerable<HobbyComment>> GetAllEntitiesAsync()
        {
            return await _context.HobbyComments
                 .Include(x=>x.User)
                .ToListAsync();
        }

        public async Task<HobbyComment> GetByIdAsync(int id)
        {
            await IsValidId(id);
            var comment =await FindById(id);
            return await Task.FromResult(comment);
        }

    
        public async Task<HobbyComment> Update(HobbyComment comment)
        {
            await IsValidId(comment.Id);
            _context.HobbyComments.Update(comment);
            return comment;
        }
        public Task<bool> IsValidId(int id)
        {
            if (id <= 0) 
                throw new NullReferenceException("Comment Id must be positive");

           return Task.FromResult(true);
        }

        public async Task<HobbyComment> FindById(int id)
        {
            var comment = await _context.HobbyComments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null) throw new InvalidOperationException("Comment with Id" + id + "does not exist!");
            return comment;
        }
    }
}
