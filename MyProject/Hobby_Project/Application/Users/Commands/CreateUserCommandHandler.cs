using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    { 
        private readonly IUserRepository _userRepository;

       public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        Task<int> IRequestHandler<CreateUserCommand, int>.Handle(CreateUserCommand userCommand, CancellationToken cancellationToken)
        {
            var userHobbies = userCommand.Hobbies.Select(hobby =>
               new HobbyArticle(hobby.Title, hobby.Description, hobby.HobbySubCategory, hobby.Comments, hobby.Tags)).ToList();

            var user = new User(userCommand.Username, userCommand.FirstName, userCommand.LastName, userCommand.Email, userCommand.Age, userHobbies);
            _userRepository.CreateUser(user);
            return Task.FromResult(user.ID);
        }
    }
    
}
