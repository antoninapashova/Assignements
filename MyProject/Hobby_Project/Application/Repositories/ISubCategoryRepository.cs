using Hobby_Project;

namespace Application.Repositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
         Task<bool> CheckSubCategoryExists(string name);
    }
}
