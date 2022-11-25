using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICategoryRepository
    {
        void CreateCategory(HobbyCategory hobbyCategory);
        void AddSubCategoryToCategory(int categoryId, HobbySubCategory hobbySubCategory);
        void DeleteCategory(HobbyCategory hobbyCategory);
        void UpdateCategory(int categoryID, string name);
        HobbyCategory GetHobbyCategory(int id);
        IEnumerable<HobbyCategory> GetAllCategories();
        void DeleteCategoryByID(int id);
    }
}
