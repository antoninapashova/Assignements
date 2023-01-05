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
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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

            var categories = await _repoMock.Object.GetAllEntitiesAsync();

            result.Should().BeOfType<HobbyCategory>();
            
            result.Should().NotBeNull();

            categories.Count().Should().Be(4);
        }

        [Fact]
        public async Task Create_Category_Handle_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);

            var handler = new CreateCategoryCommandHandler(_unitOfWorkMock.Object, _mapper);

           await Should.ThrowAsync<NullReferenceException>(async()=>
           await handler.Handle(null, CancellationToken.None));

            var categories = await _repoMock.Object.GetAllEntitiesAsync();
            categories.Count().Should().Be(3);
        }


        [Fact]
        public async Task Edit_Category_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);
            
            var command = new EditCategoryCommand{Id = 2, Name = "Music"};

            var handler = new EditCategoryCommandHandler(_unitOfWorkMock.Object, _mapper);

            var updatedEntity = await handler.Handle(command, CancellationToken.None);

            updatedEntity.Should().NotBeNull();
            updatedEntity.Should().BeOfType<HobbyCategory>();
            
        }

        [Fact]
        public async Task Delete_Category_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);

            var handler = new DeleteCategoryCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteCategoryCommand { Id = 1 }, CancellationToken.None);

            var categories = await _repoMock.Object.GetAllEntitiesAsync();
            categories.Count().Should().Be(2);

        }

        [Fact]
        public async Task Delete_Category_Handle_Test_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.CategoryRepository).Returns(_repoMock.Object);

            var handler = new DeleteCategoryCommandHandler(_unitOfWorkMock.Object);

            await Should.ThrowAsync<NullReferenceException>
                (async () => await handler.Handle(null, CancellationToken.None));

            var categories = await _repoMock.Object.GetAllEntitiesAsync();
            categories.Count().Should().Be(3);

        }
    }
}
