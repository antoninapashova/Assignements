using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Delete
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHobbyRepository _hobbyRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, IHobbyRepository hobbyRepository)
        {
            _userRepository = userRepository;
            _hobbyRepository = hobbyRepository;
        }

        public Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            User user = _userRepository.DeleteUser(command.Id);
            user.Hobbies.ForEach(c=>_hobbyRepository.DeleteHobby(c));

            return Task.FromResult(user.Id);

        }
    }
}
