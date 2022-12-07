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
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.UserRepository.DeleteAsync(command.Id);
            await _unitOfWork.Save();
            return await Task.FromResult(command.Id);
        }
    }
}
