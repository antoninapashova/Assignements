using Application.Repositories;
using Hobby_Project;
using Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace HobbyProjectTests
{
    public class CategoryRepositoryTesting
    {
        /*
        //xUnit void,  mock repository
        private readonly Mock<ICategoryRepository> _categoryRepository = new();
        private readonly Mock<List<HobbySubCategory>> _hobbySubCategory = new();

        public CategoryRepositoryTesting()
        {
            var category = new HobbyCategory("Sport", _hobbySubCategory.Object);
            _categoryRepository.Setup(x => x.CreateCategory(category));
        }


        [Fact]
        public void AddCategoryTest()
        {


          
            var savedCategory = Assert.Single(_categoryRepository.Object.GetAllCategories());
            Assert.NotNull(savedCategory);
            Assert.Equal("Sport", savedCategory.Name);
           
        }

        [Fact]
        public void UpdateCategotyTest()
        {
            _categoryRepository.Verify(x => x.UpdateCategory(-1, "Sports"), Times.Never);

        }
        

        [Fact]
        public void CategoryByIdTest()
        {
            _categoryRepository.Verify(x => x.GetHobbyCategory(-1), Times.Never);
        }

        [Fact]
        public void DeleteCategoryByIdTest()
        {
            _categoryRepository.Verify(x => x.GetHobbyCategory(-1), Times.Never);
        }

        */
       
    }
}
