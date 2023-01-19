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
           var hobbyComment =  await FindById(id);

            return await Task.FromResult(hobbyComment);
        }

        public async Task<HobbyComment> Update(HobbyComment comment)
        {
             await FindById(comment.Id);
            _context.ChangeTracker.Clear();
            _context.HobbyComments.Update(comment);
            return comment;
        }

        public async Task<HobbyComment> FindById(int id)
        {
            var comment = await _context.HobbyComments.Include(x=>x.User)
                                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)  throw new NullReferenceException("Comment with Id " + id + " does not exist!");

            return comment;
        }
    }
}
