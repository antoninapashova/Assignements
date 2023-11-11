using Application.Repositories;
using HobbyProject.Domain.Entity;

namespace HobbyProject.Application.Repositories
{
    public interface IReplyRepository : IRepository<Reply>
    {
        Task<IEnumerable<Reply>> GetAllRepliesByCommentId(int commentId);
    }
}
