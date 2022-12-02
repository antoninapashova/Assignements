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
        private ILog _log;
        public DeleteHobbyCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
               HobbyComment hobbyComment = _commentRepository.GetHobbyComment(request.Id);
              _commentRepository.DeleteComment(hobbyComment);
               return Task.FromResult(hobbyComment.Id);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
        }
    }
}
