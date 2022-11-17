using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Hobby_Project;

namespace Infrastructure
{
    internal class InMemoryCategoryRepository : ICategoryRepository
    {

        List<HobbyCategory> _categories = new();

        public void AddSubCategoryToCategory(int categoryId, HobbySubCategory hobbySubCategory)
        {
            var category = _categories.FirstOrDefault(c => c.ID == categoryId);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");
            category.HobbySubCategories.Add(hobbySubCategory);
        
    }

        public void CreateCategory(HobbyCategory hobbyCategory)
        {
            _categories.Add(hobbyCategory);
            hobbyCategory.ID = _categories.Count;
        }

        public void DeleteCategory(HobbyCategory hobbyCategory)
        {
            var category = _categories.FirstOrDefault(c => c.ID == hobbyCategory.ID);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");

            this._categories.Remove(hobbyCategory);
        }

        public IEnumerable<HobbyCategory> GetAllCategories()
        {
            return this._categories;
        }

        public HobbyCategory GetHobbyCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.ID == id);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");
            return category;
        }

        public void UpdateCategory(int categoryId,HobbyCategory newHobbyCategory)
        {
            var category = _categories.FirstOrDefault(c => c.ID == categoryId);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");
            category.ChangeName(newHobbyCategory.Name);
            category.AddedOn = DateTime.Now;
        }
    }
}
