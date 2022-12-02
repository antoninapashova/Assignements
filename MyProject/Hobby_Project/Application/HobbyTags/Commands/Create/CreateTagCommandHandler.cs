using Application.HobbyTags.Queries;
using Application.Logger;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Commands.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly ITagRepository _tagRepository;
        private ILog _log;
        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(CreateTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create tag command is null!");
               var tag = new Tag(command.Name);

               _tagRepository.CreateTag(tag);
               return Task.FromResult(tag.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
            
        }
    }
}
