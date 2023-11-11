using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using FluentAssertions;
using Hobby_Project;
using HobbyProjectTests.Mocks;
using Moq;
using Shouldly;

namespace HobbyProjectTests.Commands
{
    public class CategoryCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ICategoryRepository> _repoMock;
        private readonly IMapper _mapper;
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

            result.Should().BeOfType<Category>();
            
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
