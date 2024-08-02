using HobbyProject.Application.Repositories;
using HobbyProject.Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(Reply reply)
        {
            _context.Replies.Remove(reply);
        }

        public async Task<bool> FindById(int id)
        {
            return await _context.Replies.AsNoTracking().AnyAsync(r => r.Id == id);
        }

        public IEnumerable<Reply> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reply> GetAllRepliesByCommentId(int commentId)
        {
           return _context.Replies.Include(x=>x.User).Where(r => r.CommentId == commentId);
        }

        public async Task<Reply> GetByIdAsync(int id)
        {
            return await _context.Replies.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Reply Update(Reply entity)
        {
            throw new NotImplementedException();
        }
    }
}
