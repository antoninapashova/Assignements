using Application.Repositories;
using Azure;
using Hobby_Project;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Mocks
{
    public static class MockTagRepository
    {
        public static Mock<ITagRepository> GetTagRepository()
        {
            var tags = new List<Tag>
            {
               new Tag{ Id = 1, CreatedDate = DateTime.Now, Name = "Outside sport"}, 
               new Tag{Id = 2,CreatedDate = DateTime.Now,Name = "Vegetarian food"}
            };
            var mockRepo = new Mock<ITagRepository>();
            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(tags);

            mockRepo.Setup(x => x.Add(It.IsAny<Tag>())).ReturnsAsync((Tag tag) =>
            {
                tags.Add(tag);
                return tag;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<Tag>())).ReturnsAsync((Tag tag) =>
            {
                Tag? tag1 = tags.FirstOrDefault(x => x.Id == tag.Id);
                tag1.Name = tag.Name; 
                return tag1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int tagId) =>
            {
                Tag? tag1 = tags.FirstOrDefault(x => x.Id == tagId);
                tags.Remove(tag1);
                return Task.FromResult(tag1.Id);
            });

            return mockRepo;
        }
    }
}
