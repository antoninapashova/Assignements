using Application.Logger;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Delete
{
    public  class DeleteHobbyCommandHandler : IRequestHandler<DeleteCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteHobbyCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            HobbyComment hobbyComment = _commentRepository.GetHobbyComment(request.Id);
            _commentRepository.DeleteComment(hobbyComment);
            SingletonLogger.Instance.LogMessage("delete", "User " + hobbyComment.User.Username + " delete comment with title: " + hobbyComment.Title);
            return Task.FromResult(hobbyComment.Id);
        }
    }
}
