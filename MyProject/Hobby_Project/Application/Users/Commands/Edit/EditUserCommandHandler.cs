using Application.Logger;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Edit
{
    internal class EditUserCommandHandler : IRequestHandler<EditUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            User currentUser = _userRepository.GetUser(command.Id);
            _userRepository.UpdateUser(command.Id, command.Username, command.FirstName, command.LastName, command.Email);
            return Task.FromResult(command.Id);
        }
    }
}
