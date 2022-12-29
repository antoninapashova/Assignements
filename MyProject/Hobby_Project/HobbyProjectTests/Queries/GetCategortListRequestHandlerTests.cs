using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using FluentAssertions;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProjectTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Queries
{
    public class GetCategortListRequestHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ICategoryRepository> _repoMock;
        private IMapper _mapper;
        public GetCategortListRequestHandlerTests()
        { 
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockCategoryRepositories.GetCategoryRepository();
        }

        [Fact]
        public async Task Get_All_Categories_Returns_List_Test()
        {
           
            _unitOfWorkMock.Setup(x =>x.CategoryRepository).Returns(_repoMock.Object);
            var handler = new GetCategoryListQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
            
            result.Should().BeOfType<List<CategoryDto>>();
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_Category_By_Id_Test()
        {
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);

            var category = new HobbyCategory
            {
                Id = 1,
                Name = "Sports",
                CreatedDate = DateTime.Now,
                HobbySubCategories = new List<HobbySubCategory>()
            };
           _repoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(category);
            var handler = new GetCategoryByIdHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetCategoryByIdQuery { Id= 1}, CancellationToken.None);
           result.Should().BeOfType<CategoryDto>();
            result.Should().NotBeNull();
        }
    }
}
