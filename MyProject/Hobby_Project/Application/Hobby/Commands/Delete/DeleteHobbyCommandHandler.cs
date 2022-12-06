using Application.Logger;
using Application.Repositories;
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
        private readonly IHobbyArticleRepository _hobbyRepository;
        private readonly ICommentRepository _commentRepository;
        private ILog _log;
        public DeleteHobbyCommandHandler(IHobbyArticleRepository hobbyRepository, ICommentRepository commentRepository)
        {
            _hobbyRepository = hobbyRepository;
            _commentRepository = commentRepository;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Delete hobby command is null");
                HobbyArticle hobbyArticle = await _hobbyRepository.GetByIdAsync(command.Id);
                hobbyArticle.HobbyComments.ToList().ForEach(c => _commentRepository.DeleteAsync(c.Id));
                return await Task.FromResult(command.Id);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
