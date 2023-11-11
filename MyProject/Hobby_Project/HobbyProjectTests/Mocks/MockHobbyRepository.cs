using Application.Repositories;
using Domain.Entity;
using Moq;
using HobbyProject.Domain.Entity;

namespace HobbyProjectTests.Mocks
{
    public static class MockHobbyRepository
    {     
        public static Mock<IHobbyArticleRepository> GetHobbyArticleRepository()
        {
            var hobbyArticles = new List<HobbyEntity>
            {
                new HobbyEntity {Id = 1, Title="A great day for playing tennis", Description="---------",
                                  CreatedDate= DateTime.Now, 
                    HobbySubCategoryId=1,
                                  Tags = new List<Tag>()},
                new HobbyEntity {Id = 2, Title="A great day for playing tennis", Description="---------",
                                  CreatedDate= DateTime.Now, 
                    HobbySubCategoryId=1,
                                  Tags = new List<Tag>()},
                new HobbyEntity {Id = 3, Title="A great day for playing tennis", Description="---------",
                                  CreatedDate= DateTime.Now, 
                    HobbySubCategoryId=1,
                                  Tags = new List<Tag>()},
            };

            var mockRepo = new Mock<IHobbyArticleRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(hobbyArticles);

            mockRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                HobbyEntity? hobbyArticle1 = hobbyArticles.FirstOrDefault(x => x.Id == id);
                return hobbyArticle1;
            });

            mockRepo.Setup(x => x.Add(It.IsAny<HobbyEntity>())).ReturnsAsync((HobbyEntity hobbyArticle) =>
            {
                hobbyArticles.Add(hobbyArticle);
                return hobbyArticle;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<HobbyEntity>())).ReturnsAsync((HobbyEntity hobbyArticle) =>
            {
                HobbyEntity? hobbyArticle1 = hobbyArticles.FirstOrDefault(x => x.Id == hobbyArticle.Id);
                hobbyArticle1.Title = hobbyArticle.Title;
                hobbyArticle1.Description = hobbyArticle.Description;
                hobbyArticle1.CreatedDate = DateTime.Now;
                hobbyArticle1.HobbySubCategoryId = hobbyArticle.HobbySubCategoryId;
                return hobbyArticle1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int articleId) =>
            {
                HobbyEntity? article= hobbyArticles.FirstOrDefault(x => x.Id == articleId);
                hobbyArticles.Remove(article);
                return Task.FromResult(article.Id);
            });

            return mockRepo;
        }
    }
}
