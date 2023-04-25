using Hobby_Project;
using HobbyProject.Application.Repositories;
using HobbyProject.Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Infrastructure.Repository
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly HobbyDbContext _context;

        public ReplyRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Reply> Add(Reply entity)
        {
           await _context.Replies.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            Reply reply = await FindById(id);
            _context.Replies.Remove(reply);
        }

        public async Task<Reply> FindById(int id)
        {
            var reply = await _context.Replies.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);

            return reply ?? throw new NullReferenceException("Reply is null!");
        }

        public Task<IEnumerable<Reply>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reply>> GetAllRepliesByCommentId(int commentId)
        {
          return _context.Replies.Include(x=>x.User).Where(r => r.CommentId == commentId);
        }

        public Task<Reply> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> Update(Reply entity)
        {
            throw new NotImplementedException();
        }
    }
}
