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
using HobbyProject.Application.HobbySubCategories.Queries.GetAllSubCategories;
using FluentAssertions;
using Application.Hobby.Queries;
using HobbyProject.Application.Hobby.Queries.GetHobbyById;
using HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById;

namespace HobbyProjectTests.Queries
{
    public class GetSubCategoryListRequestHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ISubCategoryRepository> _repoMock;
        private IMapper _mapper;

        public GetSubCategoryListRequestHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockSubCategoryRepository.GetAllSubCategories();
        }

        [Fact]
        public async Task Get_All_SubCategories_Returns_List_Test()
        {
            _unitOfWorkMock.Setup(x => x.SubCategoryRepository).Returns(_repoMock.Object);
            var handler = new GetSubCategoryListQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetSubCategoryListQuery(), CancellationToken.None);

            result.Should().BeOfType<List<HobbySubCategoryDto>>();
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_SubCategory_By_IdReturns_SubCategory_Test()
        {
            _unitOfWorkMock.Setup(x => x.SubCategoryRepository).Returns(_repoMock.Object);
            var handler = new GetSubCategoryByIdQueryHandler(_mapper, _unitOfWorkMock.Object);
            var result = await handler.Handle(new GetSubCategoryQuery { Id = 1 }, CancellationToken.None);
            result.Should().BeOfType<HobbySubCategoryDto>();
            result.Should().NotBeNull();
        }

    }
}
