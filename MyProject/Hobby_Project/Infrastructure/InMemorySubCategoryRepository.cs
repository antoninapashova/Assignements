using Application;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class InMemorySubCategoryRepository : ISubCategoryRepository
    {
        List<HobbySubCategory> subCategories = new();
        public void AddSubCategory(HobbySubCategory hobbySubCategory)
        {
            subCategories.Add(hobbySubCategory);
        }

        public void DeleteSubCategory(int subCategoryId)
        {
            HobbySubCategory subCategory = isValid(subCategoryId);
            subCategories.Remove(subCategory);
        }

        public List<HobbySubCategory> GetAllSubCategories()
        {
            return subCategories;
        }

        public HobbySubCategory GetSubCategory(int subCategoryId)
        {
            HobbySubCategory subCategory = isValid(subCategoryId);
            return subCategory;
        }

        public void UpdateSubCategory(int subCategoryId, HobbySubCategory hobbySubCategory)
        {
            HobbySubCategory subCategory = isValid(subCategoryId);
            subCategory.Name = hobbySubCategory.Name;
            subCategory.AddedOn = DateTime.Now;
        }

        private HobbySubCategory isValid(int ID)
        {
            var subCategory = subCategories.FirstOrDefault(s => s.ID == ID);
            if (subCategory == null) throw new InvalidOperationException("SubCategory with ID: " + ID + "does not exist");
            return subCategory;
        }
    }
}
