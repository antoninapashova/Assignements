using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using Application.HobbyTags.Commands.Create;
using Application.HobbyTags.Commands.Delete;
using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using FluentAssertions;
using Hobby_Project;
using HobbyProjectTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProjectTests.Commands
{
    public class TagCommandHandlerTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ITagRepository> _repoMock;
        private IMapper _mapper;
        private CreateTagCommand _tagCommand;

        public TagCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockTagRepository.GetTagRepository();
            _tagCommand = new CreateTagCommand { Name = "Winter hobbies" };
        }

        [Fact]
        public async Task Create_Tag_Handle_Returns_Category_Test()
        {
            _unitOfWorkMock.Setup(x => x.TagRepository).Returns(_repoMock.Object);
            var handler = new CreateTagCommandHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(_tagCommand, CancellationToken.None);
            result.Should().BeOfType<Tag>();
        }

        [Fact]
        public async Task Delete_Category_Handle_Test()
        {
            _repoMock.Setup(x => x.DeleteAsync(1));
            _unitOfWorkMock.Setup(x => x.TagRepository).Returns(_repoMock.Object);

            var handler = new DeleteTagCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteTagCommand { Id = 1 }, CancellationToken.None);
            Assert.Equal(1, result);
        }
    }
}
