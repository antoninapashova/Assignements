using Application.Logger;
using Application.Repositories;
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

        public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
               await _commentRepository.DeleteAsync(request.Id);
               return await Task.FromResult(request.Id);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
