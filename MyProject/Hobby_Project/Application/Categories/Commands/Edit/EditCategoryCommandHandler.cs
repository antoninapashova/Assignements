using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Logger;
using System.Reflection.Emit;

namespace Application.Categories.Commands.Edit
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private ILog _log;

        public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Edit category command is null");
                _categoryRepository.UpdateCategory(command.Id, command.Name);
                return Task.FromResult(command.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
        }
    }
}
