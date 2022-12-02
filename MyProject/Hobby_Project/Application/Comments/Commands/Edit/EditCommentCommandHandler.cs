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
        private ILog _log;

        public EditCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(EditCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Edit comment command is null");
                HobbyComment hobbyComment = _commentRepository.GetHobbyComment(command.Id);
                HobbyComment newHobbyComment = new HobbyComment(command.Title, command.CommentContent, hobbyComment.User);
                _commentRepository.UpdateComment(command.Id, newHobbyComment);
                return Task.FromResult(command.Id);

            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
           
        }
    }
}
