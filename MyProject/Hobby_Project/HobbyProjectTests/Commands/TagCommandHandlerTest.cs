using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.HobbyTags.Commands.Create;
using Application.HobbyTags.Commands.Delete;
using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using FluentAssertions;
using Hobby_Project;
using HobbyProject.Domain.Entity;
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
    public class TagCommandHandlerTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ITagRepository> _repoMock;
        private readonly IMapper _mapper;
        private CreateTagCommand _tagCommand;

        public TagCommandHandlerTest()
        {
            _repoMock = MockTagRepository.GetTagRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            
            _tagCommand = new CreateTagCommand { Name = "" };
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
        public async Task Create_Tag_Handle_Returns_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.TagRepository).Returns(_repoMock.Object);

            var handler = new CreateTagCommandHandler(_unitOfWorkMock.Object, _mapper);

            await Should.ThrowAsync<NullReferenceException>(async () => 
                await handler.Handle(null, CancellationToken.None));

            var tags = await _repoMock.Object.GetAllEntitiesAsync();
            tags.Count().Should().Be(2);
        }

        [Fact]
        public async Task Delete_Category_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.TagRepository).Returns(_repoMock.Object);

            var handler = new DeleteTagCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteTagCommand { Id = 1 }, CancellationToken.None);
            var tags = await _repoMock.Object.GetAllEntitiesAsync();
           
            tags.Count().Should().Be(1);
        }
    }
}
