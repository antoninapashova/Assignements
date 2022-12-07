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
    internal class CommentRepository : ICommentRepository
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
            HobbyComment comment = await IsValid(id);
            _context.HobbyComments.Remove(comment);
            
        }

        public async Task<IEnumerable<HobbyComment>> GetAllEntitiesAsync()
        {
            return await _context.HobbyComments.ToListAsync();
        }

        public async Task<HobbyComment> GetByIdAsync(int id)
        {
            HobbyComment comment = await IsValid(id);
            return comment;
        }
        public async Task UpdateAsync(int id, HobbyComment comment)
        {
            HobbyComment existingComment = await IsValid(id);
            _context.Update(comment);
            //Refactor
           
        }

        private async Task<HobbyComment> IsValid(int commentId)
        {
            if (commentId <= 0) throw new NullReferenceException("Comment Id musr be positive");
            var comment = await _context.HobbyComments.FirstOrDefaultAsync(c => c.Id == commentId);
            if (comment == null) throw new InvalidOperationException("Comment with Id" + commentId + "does not exist!");
            return comment;
        }
    }
}
