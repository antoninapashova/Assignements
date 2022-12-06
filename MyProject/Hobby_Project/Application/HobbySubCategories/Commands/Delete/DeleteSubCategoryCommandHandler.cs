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
        private readonly ISubCategoryRepository _subCategoryRepository;
        private ILog _log;
        public DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Delete sub category command is null!");
                await _subCategoryRepository.DeleteAsync(command.Id);
                return await Task.FromResult(command.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
