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
using FluentAssertions;
using HobbyProject.Application.Hobby.Queries.GetAllUsers;
using Application.Hobby.Queries;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Hobby.Queries.GetHobbyById;

namespace HobbyProjectTests.Queries
{
     public class GetHobbyListRequestHandlerTests
     {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IHobbyArticleRepository> _repoMock;
        private IMapper _mapper;

        public GetHobbyListRequestHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockHobbyRepository.GetHobbyArticleRepository();
        }

        [Fact]
        public async Task Get_All_Hobbies_Returns_List_Test()
        {
           _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);
            var handler = new GetHobbyListQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetHobbyListQuery(), CancellationToken.None);
            var hobbies = await _repoMock.Object.GetAllEntitiesAsync();
            result.Should().BeOfType<List<HobbyDto>>();
            result.Should().NotBeNull();
            hobbies.Count().Should().Be(3);
        }

        [Fact]
        public async Task Get_Hobby_By_Id_Test()
        {
            _unitOfWorkMock.Setup(x => x.HobbyArticleRepository).Returns(_repoMock.Object);
            var handler = new GetHobbyByIdQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetHobbyByIdQuery { Id = 1 }, CancellationToken.None);
            result.Should().BeOfType<HobbyDto>();
            result.Should().NotBeNull();
        }

    }
}
