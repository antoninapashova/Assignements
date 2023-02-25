using Application.Mapping;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries;
using HobbyProjectTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.HobbyTags.Queries;
using HobbyProject.Application.HobbyTags.Queries;
using FluentAssertions;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.HobbyTags.Queries.GetTagById;
using HobbyProject.Domain.Entity;

namespace HobbyProjectTests.Queries
{
    public class GetTagListRequestHandlerTests
    {

        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ITagRepository> _repoMock;
        private IMapper _mapper;

        public GetTagListRequestHandlerTests()
        {

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockTagRepository.GetTagRepository();
        }
        [Fact]
        public async Task Get_All_Tags_Returns_List_Test()
        {

            _unitOfWorkMock.Setup(x => x.TagRepository).Returns(_repoMock.Object);
            var handler = new GetTagListQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetTagQuery(), CancellationToken.None);

            result.Should().BeOfType<List<TagDto>>();
            result.Should().NotBeNull();
        }


        [Fact]
        public async Task Get_Tag_By_Id_Test()
        {
            _unitOfWorkMock.Setup(x => x.TagRepository).Returns(_repoMock.Object);

            var tag = new Tag
            {
                Id = 1,
                Name = "Sports",
                CreatedDate = DateTime.Now,
            };
            _repoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(tag);
            var handler = new GetTagByIdQueryHandler (_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetTagByIdQuery { Id = 1 }, CancellationToken.None);
            result.Should().BeOfType<TagDto>();
            result.Should().NotBeNull();
        }

    }
}
