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

        public async Task<Comment> Add(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await FindById(id);
            _context.Comments.Remove(comment);
        } 

        public async Task<IEnumerable<Comment>> GetCommentsByHobbyId(int hobbyId)
        {
           return await _context.Comments.Where(x=>x.HobbyArticleId == hobbyId)
                .Include(x=>x.User)
                 
                .ToListAsync();
        }

        public async Task<Comment> Update(Comment comment)
        {
            await FindById(comment.Id);
            _context.ChangeTracker.Clear();
            _context.Comments.Update(comment);
            return comment;
        }

        public async Task<Comment> FindById(int id)
        {
            var comment = await _context.Comments
                                //.Include(x=>x.Username)
                                .FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null) throw new NullReferenceException("Comment with Id " + id + " does not exist!");

            return comment;
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}