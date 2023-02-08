using Application.Repositories;
using Domain.Entity;
using Hobby_Project;
using HobbyProject.Application.Hobby.Commands;
using HobbyProject.Application.Hobby;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmptyFiles;

namespace HobbyProjectTests.Mocks
{
    public static class MockHobbyRepository
    {     
        public static Mock<IHobbyArticleRepository> GetHobbyArticleRepository()
        {
            var hobbyArticles = new List<HobbyArticle>
            {
                new HobbyArticle {Id = 1, Title="A great day for playing tennis", Description="---------",
                                  CreatedDate= DateTime.Now, Username = "Ivan", HobbySubCategoryId=1,
                                  Tags = new List<Tag>()},
                new HobbyArticle {Id = 2, Title="A great day for playing tennis", Description="---------",
                                  CreatedDate= DateTime.Now, Username="Ivan", HobbySubCategoryId=1,
                                  Tags = new List<Tag>()},
                new HobbyArticle {Id = 3, Title="A great day for playing tennis", Description="---------",
                                  CreatedDate= DateTime.Now, Username = "Ivan", HobbySubCategoryId=1,
                                  Tags = new List<Tag>()},
            };

            var mockRepo = new Mock<IHobbyArticleRepository>();

            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(hobbyArticles);

            mockRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                HobbyArticle? hobbyArticle1 = hobbyArticles.FirstOrDefault(x => x.Id == id);
                return hobbyArticle1;
            });

            mockRepo.Setup(x => x.Add(It.IsAny<HobbyArticle>())).ReturnsAsync((HobbyArticle hobbyArticle) =>
            {
                hobbyArticles.Add(hobbyArticle);
                return hobbyArticle;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<HobbyArticle>())).ReturnsAsync((HobbyArticle hobbyArticle) =>
            {
                HobbyArticle? hobbyArticle1 = hobbyArticles.FirstOrDefault(x => x.Id == hobbyArticle.Id);
                hobbyArticle1.Title = hobbyArticle.Title;
                hobbyArticle1.Description = hobbyArticle.Description;
                hobbyArticle1.CreatedDate = DateTime.Now;
                hobbyArticle1.HobbySubCategoryId = hobbyArticle.HobbySubCategoryId;
                return hobbyArticle1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int articleId) =>
            {
                HobbyArticle? article= hobbyArticles.FirstOrDefault(x => x.Id == articleId);
                hobbyArticles.Remove(article);
                return Task.FromResult(article.Id);
            });

           return mockRepo;
        }
    }
}
