using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ISubCategoryRepository
    {
        void AddSubCategory(HobbySubCategory hobbySubCategory);
        void UpdateSubCategory (int subCategoryId, HobbySubCategory hobbySubCategory);
        void DeleteSubCategory (int subCategoryId);
        HobbySubCategory GetSubCategory(int subCategoryId);
        List<HobbySubCategory> GetAllSubCategories();
    }
}
