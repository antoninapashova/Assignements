using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Logger;

namespace Application.Categories.Commands.Edit
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            _categoryRepository.UpdateCategory(command.Id, command.Name);
            SingletonLogger.Instance.LogMessage("update", "The name of category with Id: " + command.Id + " is changed to" + command.Name);
            return Task.FromResult(command.Id);
        }
    }
}
