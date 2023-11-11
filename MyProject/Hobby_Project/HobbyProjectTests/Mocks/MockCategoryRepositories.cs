using Application.Repositories;
using Hobby_Project;
using Moq;

namespace HobbyProjectTests.Mocks
{
    public static class MockCategoryRepositories
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category{Id = 1, Name = "Sports", CreatedDate = DateTime.Now, HobbySubCategories = new List<SubCategory>()},
                new Category { Id = 2, Name = "Food", CreatedDate = DateTime.Now, HobbySubCategories = new List<SubCategory>()},
                new Category {Id = 3, Name = "Photography", CreatedDate= DateTime.Now, HobbySubCategories = new List<SubCategory>()},
            };

            var mockRepo = new Mock<ICategoryRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(categories);

            mockRepo.Setup(x => x.Add(It.IsAny<Category>())).ReturnsAsync((Category hobbyCategory) =>
            {
                categories.Add(hobbyCategory);
                return hobbyCategory;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<Category>())).ReturnsAsync((Category hobbyCategory) =>
            {
                Category? hobbyCategory1 = categories.FirstOrDefault(x => x.Id == hobbyCategory.Id);
                hobbyCategory1.Name = hobbyCategory.Name;
                return hobbyCategory1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int categoryId) =>
            {
                Category? hobbyCategory1 = categories.FirstOrDefault(x => x.Id == categoryId);
                categories.Remove(hobbyCategory1);
                return Task.FromResult(hobbyCategory1.Id);
            });

            return mockRepo;
        }
    }
}
