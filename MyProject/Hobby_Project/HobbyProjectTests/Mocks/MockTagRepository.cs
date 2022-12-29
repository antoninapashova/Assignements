using Application.Repositories;
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
               new Tag
               {
                   Id = 1,
                   CreatedDate = DateTime.Now,
                   Name = "Outside sport",
               }, 
               new Tag
               {
                   Id = 2,
                   CreatedDate = DateTime.Now,
                   Name = "Vegetarian food"
               }
            };
            var mockRepo = new Mock<ITagRepository>();
            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(tags);
            return mockRepo;
        }
    }
}
