using Application.Logger;
using Application.Repositories;
using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Create
{
    public class CreateUserCommandHandler 
        //: IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /*
          async Task<int> IRequestHandler<CreateUserCommand, int>.Handle(CreateUserCommand userCommand, CancellationToken cancellationToken)
         {
             var userHobbies = new List<HobbyArticle>();

             var user = new User(userCommand.Username, userCommand.FirstName, userCommand.LastName, userCommand.Email, userCommand.Age, userHobbies);
             await _userRepository.Add(user);
             return await Task.FromResult(user.Id);
         }
        */
         
    }

}
