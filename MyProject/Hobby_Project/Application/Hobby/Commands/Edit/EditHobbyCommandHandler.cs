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
        private ILog _log;

        public EditHobbyCommandHandler(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(EditHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
               if (command == null) throw new NullReferenceException("Edit hobby command is null");
              _hobbyRepository.EditHobby(command.Id, command.Title, command.Description);
               return Task.FromResult(command.Id);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
            
        }
    }
}
