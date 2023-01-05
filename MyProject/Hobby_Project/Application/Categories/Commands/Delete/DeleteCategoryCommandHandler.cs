using Application.Logger;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
               if (command == null)
                    throw new NullReferenceException("Delete category command is null");

                await _unitOfWork.CategoryRepository.DeleteAsync(command.Id);
                await _unitOfWork.Save();

               return await Task.FromResult(command.Id);

            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
  ;         }
        }
    }
}
