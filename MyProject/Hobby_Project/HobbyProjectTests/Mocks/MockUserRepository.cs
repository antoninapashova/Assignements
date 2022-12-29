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
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<User>
            {
               new User
               {
                   Id  = 1,
                   Username = "username",
                   FirstName = "firstName",
                   LastName = "lastName",
                   Email = "email@gmail.com",
                   Age = 20
               }
            };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(users);
            return mockRepo;
        }
    }
}
