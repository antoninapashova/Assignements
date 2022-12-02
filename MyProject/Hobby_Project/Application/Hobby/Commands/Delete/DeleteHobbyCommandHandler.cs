using Application.Logger;
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
        private ILog _log;
        public DeleteHobbyCommandHandler(IHobbyRepository hobbyRepository, ICommentRepository commentRepository)
        {
            _hobbyRepository = hobbyRepository;
            _commentRepository = commentRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(DeleteHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Delete hobby command is null");
                HobbyArticle hobbyArticle = _hobbyRepository.DeleteHobbyById(command.Id);
                hobbyArticle.Comments.ForEach(c => _commentRepository.DeleteComment(c));
                return Task.FromResult(command.Id);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
        }
    }
}
