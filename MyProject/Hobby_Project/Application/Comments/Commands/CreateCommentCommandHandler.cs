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
        private readonly IUserRepository _userRepository;

        public CreateCommentCommandHandler(ICommentRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        Task<int> IRequestHandler<CreateCommentCommand, int>.Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            User user = _userRepository.GetUser(command.User.ID);
           
            var hobbyComment = new HobbyComment(command.Title, command.CommentContent, user);
            _repository.CreateComment(hobbyComment);
            return Task.FromResult(hobbyComment.ID);
            
        }
    }
}
