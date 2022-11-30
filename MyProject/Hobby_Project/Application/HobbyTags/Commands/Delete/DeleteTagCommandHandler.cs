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

        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Task Handle(DeleteTagCommand request, Exception exception, RequestExceptionHandlerState<int> state, CancellationToken cancellationToken)
        {
            Tag tag = _tagRepository.GetTag(request.Id);
            _tagRepository.DeleteTag(tag);
            SingletonLogger.Instance.LogMessage("delete", "Tag with Id " + tag.Id + " is deleted");
            return Task.FromResult(request.Id);
        }
    }
}
