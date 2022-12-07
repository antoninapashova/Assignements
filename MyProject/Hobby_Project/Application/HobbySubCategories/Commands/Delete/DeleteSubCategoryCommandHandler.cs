using Application.Logger;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Delete
{
    internal class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        public DeleteSubCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Delete sub category command is null!");
                await _unitOfWork.SubCategoryRepository.DeleteAsync(command.Id);
                await _unitOfWork.Save();
                return await Task.FromResult(command.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
