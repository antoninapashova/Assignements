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
               new User{Id  = 1,Username = "username",FirstName = "firstName",LastName = "lastName",Email = "email@gmail.com", Age = 20 }
               
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.GetAllEntitiesAsync()).ReturnsAsync(users);

            mockRepo.Setup(x => x.Add(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                users.Add(user);
                return user;
            });

            mockRepo.Setup(x => x.Update(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                User? user1 = users.FirstOrDefault(x => x.Id == user.Id);
                user1.Username = user.Username;
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Email = user.Email;
                user1.Age = user.Age;
                return user1;
            });

            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Int32>())).Returns((int userId) =>
            {
                User? user1 = users.FirstOrDefault(x => x.Id == userId);
                users.Remove(user1);
                return Task.FromResult(user1.Id);
            });

            return mockRepo;
        }
    }
}
