using Hobby_Project;

namespace Application.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> GetAllNames();
        Task<bool> CheckCategoryExists(string name);
    }
}
