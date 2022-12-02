using Application.Logger;
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
        private readonly ICategoryRepository _categoryRepository;
        private ILog _log;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
               if (command == null) throw new NullReferenceException("Delete category command is null");
                        
               _categoryRepository.DeleteCategoryByID(command.Id);
               return Task.FromResult(command.Id);
            }catch(Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
;           }
        }
    }
}
