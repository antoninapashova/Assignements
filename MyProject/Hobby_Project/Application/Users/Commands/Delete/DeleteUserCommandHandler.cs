using Application.Logger;
using Application.Repositories;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Delete
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHobbyArticleRepository _hobbyRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, IHobbyArticleRepository hobbyRepository)
        {
            _userRepository = userRepository;
            _hobbyRepository = hobbyRepository;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(command.Id);
            user.Hobbies.ToList().ForEach(h=>_hobbyRepository.DeleteAsync(h.Id));
            await _userRepository.DeleteAsync(command.Id);
            
            return await Task.FromResult(user.Id);
        }
    }
}
