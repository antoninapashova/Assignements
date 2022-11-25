using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            HobbyCategory hobbyCategory = _categoryRepository.GetHobbyCategory(command.Id);
            _categoryRepository.UpdateCategory(command.Id, command.Name);
            return Task.FromResult(command.Id);
        }
    }
}
