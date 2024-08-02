using Domain.Entity;

namespace Application.Repositories
{
    public interface IHobbyArticleRepository : IRepository<HobbyEntity>
    {
        IEnumerable<HobbyEntity> GetHobbyArticlesByUserId(int id);
        IEnumerable<HobbyEntity> GetHobbyArticlesByUsername(string username);
    }
}
