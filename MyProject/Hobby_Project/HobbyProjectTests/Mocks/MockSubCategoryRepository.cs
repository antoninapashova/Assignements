using Application.Repositories;
using Domain.Entity;
using EmptyFiles;
using Hobby_Project;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Mocks
{
     public static class MockSubCategoryRepository
    {
        public static Mock<ISubCategoryRepository> GetAllSubCategories()
        {
            var subCategories = new List<HobbySubCategory>
            {
                new HobbySubCategory{Id = 1, Name = "Football", CreatedDate = DateTime.Now},
                new HobbySubCategory{Id = 2, Name = "Tennis", CreatedDate = DateTime.Now},
            };

            var mockRepo = new Mock<ISubCategoryRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(subCategories);

            mockRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                HobbySubCategory? hobbySubCategory = subCategories.FirstOrDefault(x => x.Id == id);
                return hobbySubCategory;
            });

            mockRepo.Setup(x => x.Add(It.IsAny<HobbySubCategory>())).ReturnsAsync((HobbySubCategory subCategory) =>
            {
                subCategories.Add(subCategory);
                return subCategory;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int subCategoryId) =>
            {
                HobbySubCategory? hobbySubCategory1 = subCategories.FirstOrDefault(x => x.Id == subCategoryId);
                subCategories.Remove(hobbySubCategory1);
                return Task.FromResult(hobbySubCategory1.Id);
            });

            return mockRepo;
        }
    }
}
