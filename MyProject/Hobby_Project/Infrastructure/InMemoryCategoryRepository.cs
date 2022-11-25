using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Hobby_Project;

namespace Infrastructure
{
     public class InMemoryCategoryRepository : ICategoryRepository
    {

        List<HobbyCategory> _categories = new();

        public void AddSubCategoryToCategory(int categoryId, HobbySubCategory hobbySubCategory)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");
            category.HobbySubCategories.Add(hobbySubCategory);
        
        }

        public void CreateCategory(HobbyCategory hobbyCategory)
        {
            _categories.Add(hobbyCategory);
            hobbyCategory.Id = _categories.Count;
        }

        public void DeleteCategory(HobbyCategory hobbyCategory)
        {

            HobbyCategory category = isValid(hobbyCategory.Id);
            this._categories.Remove(hobbyCategory);
        }

        public void DeleteCategoryByID(int id)
        {
            HobbyCategory category = isValid(id);
            this._categories.Remove(category);
        }

        public IEnumerable<HobbyCategory> GetAllCategories()
        {
            return this._categories;
        }

        public HobbyCategory GetHobbyCategory(int id)
        {
            HobbyCategory category = isValid(id);
            return category;
        }

        public void UpdateCategory(int categoryId, string name)
        {
            HobbyCategory category = isValid(categoryId);
            category.Name = name;
            category.AddedOn = DateTime.Now;
        }

        private HobbyCategory isValid(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) throw new InvalidOperationException("Category with that id does not exist");
            return category;
        }
    }
}
