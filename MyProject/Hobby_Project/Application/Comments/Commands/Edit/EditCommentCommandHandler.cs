using Application.Logger;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Edit
{
    internal class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;

        public EditCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<int> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            HobbyComment hobbyComment = _commentRepository.GetHobbyComment(request.Id);
            HobbyComment newHobbyComment = new HobbyComment(request.Title, request.CommentContent, hobbyComment.User);
            _commentRepository.UpdateComment(request.Id, newHobbyComment);
            SingletonLogger.Instance.LogMessage("update", "Comment with Id " + hobbyComment.Id + " is edited");
            return Task.FromResult(request.Id);
        }
    }
}
