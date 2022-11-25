using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Delete
{
    public  class DeleteHobbyCommandHandler : IRequestHandler<DeleteHobbyCommand, int>
    {
        private readonly IHobbyRepository _hobbyRepository;
        private readonly ICommentRepository _commentRepository;

        public DeleteHobbyCommandHandler(IHobbyRepository hobbyRepository, ICommentRepository commentRepository)
        {
            _hobbyRepository = hobbyRepository;
            _commentRepository = commentRepository;
        }

        public Task<int> Handle(DeleteHobbyCommand command, CancellationToken cancellationToken)
        {
            HobbyArticle hobbyArticle = _hobbyRepository.DeleteHobbyById(command.Id);
            hobbyArticle.Comments.ForEach(c => _commentRepository.DeleteComment(c));
            return Task.FromResult(command.Id);
        }
    }
}
