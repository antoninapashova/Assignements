using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using Application.Hobby.Commands.Create;
using Application.Hobby.Commands.Delete;
using Application.Hobby.Commands.Edit;
using Application.Hobby.Queries;
using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using FluentAssertions;
using Hobby_Project;
using HobbyProject.Application.Hobby.Commands;
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
    public class HobbyArticleCommandHandlerTest
    {

        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IHobbyArticleRepository> _repoMock;
        private IMapper _mapper;
        private readonly CreateHobbyCommand _command;

        public HobbyArticleCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockHobbyRepository.GetHobbyArticleRepository();
            _command = new CreateHobbyCommand 
            { Title="New hobby", Description="-------", HobbySubCategoryId=1,  
                Tags = new List<CreateHobbyTagDto>(),
                HobbyPhoto = new List<PhotoDTO>() };
        }


        [Fact]
        public async Task Create_Hobby_Handler_Returns_Hobby_Test()
        {
            _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);

            var handler = new CreateHobbyCommandHandler(_unitOfWorkMock.Object, _mapper);

            var result = await handler.Handle(_command, CancellationToken.None);

            var hobbies = await _repoMock.Object.GetAllEntitiesAsync();

            result.ShouldBeOfType<Int32>();

            result.Should().ShouldNotBeNull();

            hobbies.Count().Should().Be(4);
        }

        [Fact]
        public async Task Create_Hobby_Handle_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);

            var handler = new CreateHobbyCommandHandler(_unitOfWorkMock.Object, _mapper);

            await Should.ThrowAsync<NullReferenceException>(async () =>
            await handler.Handle(null, CancellationToken.None));

            var hobbies = await _repoMock.Object.GetAllEntitiesAsync();
            hobbies.Count().Should().Be(3);
        }


        [Fact]
        public async Task Edit_Hobby_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);

            var command = new EditHobbyCommand { Id = 2, Title="New hobby 2", Description="Very nice hobby" };

            var handler = new EditHobbyCommandHandler(_unitOfWorkMock.Object, _mapper);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().ShouldNotBeNull();
            result.ShouldBeOfType<Int32>();
        }

        [Fact]
        public async Task Delete_Hobby_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);

            var handler = new DeleteHobbyCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteHobbyCommand { Id = 2 }, CancellationToken.None);

            var hobbies = await _repoMock.Object.GetAllEntitiesAsync();
            hobbies.Count().Should().Be(2);
        }

        [Fact]
        public async Task Delete_Hobby_Handle_Test_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);

            var handler = new DeleteHobbyCommandHandler(_unitOfWorkMock.Object);

            await Should.ThrowAsync<NullReferenceException>
                (async () => await handler.Handle(null, CancellationToken.None));

            var categories = await _repoMock.Object.GetAllEntitiesAsync();
            categories.Count().Should().Be(3);
        }

    }
}
