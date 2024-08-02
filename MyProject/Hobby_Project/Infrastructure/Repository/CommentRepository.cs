using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
        } 

        public IEnumerable<Comment> GetCommentsByHobbyId(int hobbyId)
        {
            return _context.Comments
                .Include(x => x.User)
                .AsQueryable()
                .Where(c => c.HobbyArticleId == hobbyId);
        }

        public Comment Update(Comment comment)
        {
            _context.ChangeTracker.Clear();
            _context.Comments.Update(comment);
            return comment;
        }

        public async Task<bool> FindById(int id)
        {
           return await _context.Comments.AsNoTracking().AnyAsync(c => c.Id == id);
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Comment> GetAllEntities()
        {
            throw new NotImplementedException();
        }
    }
}