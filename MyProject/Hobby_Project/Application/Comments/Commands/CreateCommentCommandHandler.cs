using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        Task<int> IRequestHandler<CreateCommentCommand, int>.Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            var hobbyComment = new HobbyComment(command.Title, command.CommentContent);
            _repository.CreateComment(hobbyComment);
            return Task.FromResult(hobbyComment.ID);
        }
    }
}
