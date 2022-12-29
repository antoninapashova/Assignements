using Application.Repositories;
using Hobby_Project;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Mocks
{
    public static class MockCategoryRepositories
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<HobbyCategory>
            {
                new HobbyCategory
                {
                    Id = 1,
                    Name = "Sports",
                    CreatedDate = DateTime.Now,
                    HobbySubCategories = new List<HobbySubCategory>()
                },
                new HobbyCategory { Id = 2, Name = "Food", CreatedDate = DateTime.Now, HobbySubCategories = new List<HobbySubCategory>()},
                new HobbyCategory {Id = 3, Name = "Photography", CreatedDate= DateTime.Now, HobbySubCategories = new List<HobbySubCategory>()},
            };
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(categories);
            return mockRepo;
        }
    }
}
