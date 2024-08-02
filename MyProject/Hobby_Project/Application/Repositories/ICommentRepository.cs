using Hobby_Project;

namespace Application.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetCommentsByHobbyId(int hobbyId);
    }
}
