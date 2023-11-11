using Application.Repositories;
using Hobby_Project;
using Moq;

namespace HobbyProjectTests.Mocks
{
    public static class MockSubCategoryRepository
    {
        public static Mock<ISubCategoryRepository> GetAllSubCategories()
        {
            var subCategories = new List<SubCategory>
            {
                new SubCategory{Id = 1, Name = "Football", CreatedDate = DateTime.Now},
                new SubCategory{Id = 2, Name = "Tennis", CreatedDate = DateTime.Now},
            };

            var mockRepo = new Mock<ISubCategoryRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(subCategories);

            mockRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                SubCategory? hobbySubCategory = subCategories.FirstOrDefault(x => x.Id == id);
                return hobbySubCategory;
            });

            mockRepo.Setup(x => x.Add(It.IsAny<SubCategory>())).ReturnsAsync((SubCategory subCategory) =>
            {
                subCategories.Add(subCategory);
                return subCategory;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int subCategoryId) =>
            {
                SubCategory? hobbySubCategory1 = subCategories.FirstOrDefault(x => x.Id == subCategoryId);
                subCategories.Remove(hobbySubCategory1);
                return Task.FromResult(hobbySubCategory1.Id);
            });

            return mockRepo;
        }
    }
}
