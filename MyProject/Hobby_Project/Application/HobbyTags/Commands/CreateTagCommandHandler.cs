using Application.HobbyTags.Queries;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Commands
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Task<int> Handle(CreateTagCommand tagCommand, CancellationToken cancellationToken)
        {
            var tag = new Tag(tagCommand.Name);

            _tagRepository.CreateTag(tag);
            return Task.FromResult(tag.ID);

            
        }
    }
}
