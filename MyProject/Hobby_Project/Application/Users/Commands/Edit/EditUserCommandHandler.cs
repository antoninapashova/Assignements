using Application.Logger;
using Application.Repositories;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Edit
{
    internal class EditUserCommandHandler 
        //: IRequestHandler<EditUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /*
        public async Task<int> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            User newUser = new User(command.Username, command.FirstName, command.LastName, command.Email, command.Age);
            await _userRepository.UpdateAsync(command.Id, newUser);
            return await Task.FromResult(command.Id);
        }
        */
    }
}
