using Hobby_Project;

namespace Application.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IQueryable<Category>> GetAllNamesAsync();
        Task<bool> CheckCategoryExists(string name);
    }
}
