using Application.Categories.Commands.Create;
using Application.Comments.Commands.Delete;
using Application.HobbySubCategories.Commands.Create;
using Application.HobbySubCategories.Commands.Delete;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Commands
{
    public class SubCategoryCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ISubCategoryRepository> _repoMock;
        private IMapper _mapper;
        private readonly CreateSubCategoryCommand _command;

        public SubCategoryCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockSubCategoryRepository.GetAllSubCategories();
            _command = new CreateSubCategoryCommand { Name = "Music" };
        }

        [Fact]
        public async Task Create_SubCategory_Handle_Returns_Category_Test()
        {
            _unitOfWorkMock.Setup(x => x.SubCategoryRepository).Returns(_repoMock.Object);

            var handler = new CreateSubCategoryCommandHandler(_unitOfWorkMock.Object, _mapper);

            var result = await handler.Handle(_command, CancellationToken.None);

            var subCategories = await _repoMock.Object.GetAllEntitiesAsync();

            result.Should().NotBeNull();
            result.Should().BeOfType<HobbySubCategory>();
            subCategories.Count().Should().Be(3);
        }

        [Fact]
        public async Task Create_SubCategory_Handle_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.SubCategoryRepository).Returns(_repoMock.Object);

            var handler = new CreateSubCategoryCommandHandler(_unitOfWorkMock.Object, _mapper);

            await Should.ThrowAsync<NullReferenceException>(async () =>
            await handler.Handle(null, CancellationToken.None));

            var subCategories = await _repoMock.Object.GetAllEntitiesAsync();
            subCategories.Count().Should().Be(2);
        }

        [Fact]
        public async Task Delete_SubCategory_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.SubCategoryRepository).Returns(_repoMock.Object);

            var handler = new DeleteSubCategoryCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteSubCategoryCommand { Id = 1 }, CancellationToken.None);

            var comments = await _repoMock.Object.GetAllEntitiesAsync();
            comments.Count().Should().Be(1);
        }

        [Fact]
        public async Task Delete_Commennt_Throw_Exception_Test()
        {
            _unitOfWorkMock.Setup(x => x.SubCategoryRepository).Returns(_repoMock.Object);

            var handler = new DeleteSubCategoryCommandHandler(_unitOfWorkMock.Object);

            await Should.ThrowAsync<NullReferenceException>(async () =>
                  await handler.Handle(null, CancellationToken.None));

            var comments = await _repoMock.Object.GetAllEntitiesAsync();
            comments.Count().Should().Be(2);
        }


    }
}
