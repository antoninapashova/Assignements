using Application.Logger;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _repository;
        private readonly IUserRepository _userRepository;
        private ILog _log;

        public CreateCommentCommandHandler(ICommentRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create comment command is null");
                User user = _userRepository.GetUser(command.User.ID);

                var hobbyComment = new HobbyComment(command.Title, command.CommentContent, user);
                _repository.CreateComment(hobbyComment);
                return Task.FromResult(hobbyComment.Id);
            } catch(Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
        }
    }
}
