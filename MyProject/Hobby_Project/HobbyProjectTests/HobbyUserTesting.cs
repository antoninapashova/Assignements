using Application.Repositories;
using Domain.Entity;
using Hobby_Project;
using Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests
{
    public class HobbyUserTesting
    {
        /*
        private readonly IUserRepository _userRepository;
        private readonly Mock<List<HobbyArticle>> _userArticlesMock=new();
        private User user;
        public HobbyUserTesting()
        {
            _userRepository = new UserRepository();
            user = new User(1,"ivan77", "Ivan", "Petrov", "ivan@abv.bg",20, _userArticlesMock.Object);
            _userRepository.CreateUser(user);
        }

        [Fact]
        public void CreateUserTest()
        {
            var savedUser = Assert.Single(_userRepository.GetAllUsers());
            Assert.NotNull(savedUser);
            Assert.NotEqual(4,_userRepository.GetAllUsers().Count());
        }

        [Fact]
        public void EditUserTest()
        {
            _userRepository.UpdateUser(1, "ivan88", "Ivan", "Petrov", "ivan@abv.bg");
            var user = _userRepository.GetAllUsers().First();
            Assert.Equal("ivan88", user.Username);
        }
        [Fact]
        public void DeleteUser()
        {
            _userRepository.DeleteUser(1);
            Assert.Empty(_userRepository.GetAllUsers());
        }
        */
    }
}
