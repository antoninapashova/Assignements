using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Mapping;
using Application.Repositories;
using Application.Users.Commands.Create;
using Application.Users.Commands.Delete;
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
    public class UserCommandHandlerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IUserRepository> _repoMock;
        private IMapper _mapper;
        private readonly CreateUserCommand _createUserCommand;

        public UserCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<HobbyMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _unitOfWorkMock = new();
            _repoMock = MockUserRepository.GetUserRepository();
            _createUserCommand = new CreateUserCommand {
               
                Username = "username",
                FirstName = "firstName",
                LastName = "lastName",
                Email = "email@gmail.com",
                Age = 20
            };
        }

        [Fact]
        public async Task Create_User_Handle_Returns_User_Test()
        {
            _unitOfWorkMock.Setup(x => x.UserRepository).Returns(_repoMock.Object);
            var handler = new CreateUserCommandHandler(_unitOfWorkMock.Object, _mapper);
            var result = await handler.Handle(_createUserCommand, CancellationToken.None);
            result.Should().BeOfType<User>();
            result.Email.Should().Be(_createUserCommand.Email);
        }

        [Fact]
        public async Task Create_User_Throws_Exception()
        {
            _unitOfWorkMock.Setup(x => x.UserRepository).Returns(_repoMock.Object);
            var handler = new CreateUserCommandHandler(_unitOfWorkMock.Object, _mapper);

            await Should.ThrowAsync<NullReferenceException>(async () =>
               await handler.Handle(null, CancellationToken.None));

            var users =await _repoMock.Object.GetAllEntitiesAsync();

            users.Count().Should().Be(1);
        }


        [Fact]
        public async Task Delete_User_Handle_Test()
        {
            _unitOfWorkMock.Setup(x => x.UserRepository).Returns(_repoMock.Object);
            var handler = new DeleteUserCommandHandler(_unitOfWorkMock.Object);
            var result = await handler.Handle(new DeleteUserCommand { Id = 1 }, CancellationToken.None);

            var users =await _repoMock.Object.GetAllEntitiesAsync();
            result.Should().Be(1);
            users.Count().Should().Be(0);
        }
    }
}
