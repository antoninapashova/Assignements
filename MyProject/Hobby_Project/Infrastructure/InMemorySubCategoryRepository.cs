﻿using Application;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemorySubCategoryRepository : ISubCategoryRepository
    {
        List<HobbySubCategory> subCategories = new();
        public void AddSubCategory(HobbySubCategory hobbySubCategory)
        {
            subCategories.Add(hobbySubCategory);
            hobbySubCategory.Id = subCategories.Count;
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

        private HobbySubCategory isValid(int Id)
        {
            if (Id <= 0) throw new NullReferenceException("Id must be positive");
            var subCategory = subCategories.FirstOrDefault(s => s.Id == Id);
            if (subCategory == null) throw new InvalidOperationException("SubCategory with Id: " + Id + "does not exist");
            return subCategory;
        }
    }
}
