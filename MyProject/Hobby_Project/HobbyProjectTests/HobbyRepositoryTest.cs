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
    public class HobbyRepositoryTest
    {
        /*
        private readonly IHobbyArticleRepository _repository;
        private readonly Mock<List<HobbyComment>> _comments = new();
        private readonly Mock<List<Tag>> _tags = new();
        private HobbyArticle hobbyArticle;
        private readonly Mock<HobbySubCategory> _subCategory = new();

        public HobbyRepositoryTest()
        {
            _repository = new HobbyRepository();
             hobbyArticle = new HobbyArticle(1, "Last volleyball game", 
                "It was very great time", _subCategory.Object, _comments.Object, _tags.Object);
            _repository.CreateHobby(hobbyArticle);
        }

        [Fact]
        public void AddHobbyTest()
        {
            var savedArticle = Assert.Single(_repository.GetAllHobbies());
            Assert.NotNull(savedArticle);
        }

        [Fact]
        public void EditHobbyTest()
        {
            _repository.EditHobby(1, "Last volleyball game for this season", "It was very nice play");

            var hobby = _repository.GetAllHobbies().First();
         
            Assert.NotNull(hobby);
            Assert.Equal("Last volleyball game for this season", hobby.Title);
        }

        [Fact]
        public void DeleteHobbyTest()
        {
            _repository.DeleteHobby(hobbyArticle);
            Assert.Empty(_repository.GetAllHobbies());
        }
        */
        
    }
}
