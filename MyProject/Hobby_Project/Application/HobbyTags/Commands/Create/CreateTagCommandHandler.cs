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

        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Task<int> Handle(CreateTagCommand tagCommand, CancellationToken cancellationToken)
        {
            var tag = new Tag(tagCommand.Name);

            _tagRepository.CreateTag(tag);
            SingletonLogger.Instance.LogMessage("create", "Tag with name " + tag.Name + " is added");
            return Task.FromResult(tag.Id);
        }
    }
}
