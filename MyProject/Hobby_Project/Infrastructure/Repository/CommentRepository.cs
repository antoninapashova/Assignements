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

        public async Task<IEnumerable<Comment>> GetCommentsByHobbyId(int hobbyId)
        {
            return _context.Comments
                .Include(x => x.User)
                .AsQueryable()
                .Where(c => c.HobbyArticleId == hobbyId);
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

            if (comment == null) throw new NullReferenceException($"Comment with Id: {id} does not exist!");

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