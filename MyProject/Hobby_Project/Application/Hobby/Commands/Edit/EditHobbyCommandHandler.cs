using Application.Logger;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Edit
{
    internal class EditHobbyCommandHandler : IRequestHandler<EditHobbyCommand, int>
    {
        private readonly IHobbyRepository _hobbyRepository;

        public EditHobbyCommandHandler(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        public Task<int> Handle(EditHobbyCommand command, CancellationToken cancellationToken)
        {

            _hobbyRepository.EditHobby(command.Id, command.Title, command.Description);
            SingletonLogger.Instance.LogMessage("update", "Hobby with title: " + command.Id + " is updated");
            return Task.FromResult(command.Id);
        }
    }
}
