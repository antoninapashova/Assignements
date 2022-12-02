using Application.Logger;
using Hobby_Project;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Commands.Delete
{
    internal class DeleteTagCommandHandler : IRequestExceptionHandler<DeleteTagCommand, int>
    {
        private readonly ITagRepository _tagRepository;
        private ILog _log;
        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _log = SingletonLogger.Instance;
        }

        public Task Handle(DeleteTagCommand command, Exception exception, RequestExceptionHandlerState<int> state, CancellationToken cancellationToken)
        {
            try
            {
               if (command == null) throw new NullReferenceException("Delete Tag command is null!");
               Tag tag = _tagRepository.GetTag(command.Id);
               _tagRepository.DeleteTag(tag);
               return Task.FromResult(command.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
           
        }
    }
}
