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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteHobbyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) 
                    throw new NullReferenceException("Delete hobby command is null");

                await _unitOfWork.HobbyArticleRepository.GetByIdAsync(command.Id);
                await _unitOfWork.Save();
                return await Task.FromResult(command.Id);

            }catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
