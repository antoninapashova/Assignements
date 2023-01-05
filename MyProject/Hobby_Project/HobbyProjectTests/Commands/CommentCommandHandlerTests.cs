using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using Application.Comments.Commands.Create;
using Application.Comments.Commands.Delete;
using Application.Comments.Commands.Edit;
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
     public class CommentCommandHandlerTests
     {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ICommentRepository> _repoMock;
        private IMapper _mapper;
        private readonly CreateCommentCommand _command;

        public CommentCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockCommentRepository.GetAllComments();
            _command = new CreateCommentCommand { Title="New comment", CommentContent="New comment is added", HobbyArticleId=1, UserId=1 };
        }

        [Fact]
        public async Task Create_Comment_Handle_Returns_Category_Test()
        {
            _unitOfWorkMock.Setup(x => x.CommentRepository).Returns(_repoMock.Object);

            var handler = new  CreateCommentCommandHandler(_unitOfWorkMock.Object, _mapper);

            var result = await handler.Handle(_command, CancellationToken.None);

            var categories = await _repoMock.Object.GetAllEntitiesAsync();

            result.ShouldBeOfType<Int32>();

            categories.Count().Should().Be(4);
        }

        [Fact]
        public async Task Create_Comment_Handle_Throws_Exception_Test()
        {
            _unitOfWorkMock.Setup(x => x.CommentRepository).Returns(_repoMock.Object);

            var handler = new CreateCommentCommandHandler(_unitOfWorkMock.Object, _mapper);
            
            await Should.ThrowAsync<NullReferenceException>(async () =>
                  await handler.Handle(null, CancellationToken.None));

            var comments = await _repoMock.Object.GetAllEntitiesAsync();

            comments.Count().Should().Be(3);
        }

        [Fact]
        public async Task Edit_Comment_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.CommentRepository).Returns(_repoMock.Object);

            var command = new EditCommentCommand {Id=1,  Title = "New comment", CommentContent = "New comment is added" };

            var handler = new EditCommentCommandHandler(_unitOfWorkMock.Object, _mapper);

            var updatedEntity = await handler.Handle(command, CancellationToken.None);

            updatedEntity.Should().ShouldNotBeNull();
            updatedEntity.ShouldBeOfType<Int32>();
            updatedEntity.Should().Be(1);

        }

        [Fact]
        public async Task Delete_Comment_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.CommentRepository).Returns(_repoMock.Object);

            var handler = new DeleteCommentCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteCommentCommand { Id = 1 }, CancellationToken.None);

            var comments = await _repoMock.Object.GetAllEntitiesAsync();
            comments.Count().Should().Be(2);
        }

        [Fact]
        public async Task Delete_Commennt_Throw_Exception_Test()
        {
            _unitOfWorkMock.Setup(x => x.CommentRepository).Returns(_repoMock.Object);

            var handler = new DeleteCommentCommandHandler(_unitOfWorkMock.Object);

            await Should.ThrowAsync<NullReferenceException>(async () =>
                  await handler.Handle(null, CancellationToken.None));

            var comments = await _repoMock.Object.GetAllEntitiesAsync();
            comments.Count().Should().Be(3);
        }

     }
}
