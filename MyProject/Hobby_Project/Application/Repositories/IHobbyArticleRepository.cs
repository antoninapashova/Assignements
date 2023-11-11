using Domain.Entity;

namespace Application.Repositories
{
    public interface IHobbyArticleRepository : IRepository<HobbyEntity>
    {
        Task<IEnumerable<HobbyEntity>> GetHobbyArticlesByUserId(int id);
        Task<IEnumerable<HobbyEntity>> GetHobbyArticlesByUsername(string username);
    }
}
