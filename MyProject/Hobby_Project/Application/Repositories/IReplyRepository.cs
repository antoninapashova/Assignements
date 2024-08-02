using Application.Repositories;
using HobbyProject.Domain.Entity;

namespace HobbyProject.Application.Repositories
{
    public interface IReplyRepository : IRepository<Reply>
    {
        IEnumerable<Reply> GetAllRepliesByCommentId(int commentId);
    }
}
