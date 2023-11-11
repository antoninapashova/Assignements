using HobbyProject.Domain.Entity;

namespace Application.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<bool> CheckTagExists(string name);
    }
}
