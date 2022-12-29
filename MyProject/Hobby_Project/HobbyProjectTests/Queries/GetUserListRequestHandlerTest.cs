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
using HobbyProject.Application.Users.Queries.GetAllUsers;
using Application.Users.Queries;
using FluentAssertions;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Users.Queries.GetUserById;

namespace HobbyProjectTests.Queries
{
    public class GetUserListRequestHandlerTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IUserRepository> _repoMock;
        private IMapper _mapper;

        public GetUserListRequestHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockUserRepository.GetUserRepository();
        }

        [Fact]
        public async Task Get_All_Users_Returns_List_Test()
        {

            _unitOfWorkMock.Setup(x => x.UserRepository).Returns(_repoMock.Object);
            var handler = new GetUserListQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetUserListQuery(), CancellationToken.None);

            result.Should().BeOfType<List<UserDto>>();
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_User_By_Id_Test()
        {
            _unitOfWorkMock.Setup(x => x.UserRepository).Returns(_repoMock.Object);

            var user = new User
            {
                Id = 1,
                Username = "username",
                FirstName = "firstName",
                LastName = "lastName",
                Email = "email@gmail.com",
                Age = 20
            };
            
            _repoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(user);
            var handler = new GetUserByIdQueryHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(new GetUserByIdQuery { Id = 1 }, CancellationToken.None);
            result.Should().BeOfType<UserDto>();
            result.Should().NotBeNull();
            result.Username.Should().Be(user.Username);
        }
    }
}
