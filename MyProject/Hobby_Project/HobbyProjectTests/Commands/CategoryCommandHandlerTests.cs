using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using FluentAssertions;
using Hobby_Project;
using HobbyProjectTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Commands
{
    public class CategoryCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ICategoryRepository> _repoMock;
        private IMapper _mapper;
        private readonly CreateCategoryCommand _createCategoryCommand;

        public CategoryCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockCategoryRepositories.GetCategoryRepository();
            _createCategoryCommand = new CreateCategoryCommand { Name = "Music" };

        }

        [Fact]
        public async Task Create_Category_Handle_Returns_Category_Test()
        {
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);
            var handler = new CreateCategoryCommandHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(_createCategoryCommand, CancellationToken.None);
            result.Should().BeOfType<HobbyCategory>();
            result.Should().NotBeNull();
        }
      

        [Fact]
        public async Task Edit_Category_Handle_Test()
        {
            _repoMock.Setup(or => or.Update(new HobbyCategory { Id = 1, Name = "Pets" }));
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);

            var command = new EditCategoryCommand{Id = 1, Name = "Pets"};

            var handler = new EditCategoryCommandHandler(_unitOfWorkMock.Object, _mapper);

            var updatedEntity = await handler.Handle(command, CancellationToken.None);

            updatedEntity.Should().NotBeNull();
            
        }

        [Fact]
        public async Task Delete_Category_Handle_Test()
        {
            _repoMock.Setup(x => x.DeleteAsync(1));
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);

            var handler = new DeleteCategoryCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteCategoryCommand { Id = 1 }, CancellationToken.None);
            Assert.Equal(1, result);
        }
    }
}
