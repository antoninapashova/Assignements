using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands
{
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var hobbySubCategories = command.hobbySubCategories.Select(hobbySubCategoryDTO =>
              new HobbySubCategory(hobbySubCategoryDTO.Name));


            var hobbyCategory = new HobbyCategory(command.Name, hobbySubCategories.ToList());

            return Task.FromResult(hobbyCategory.ID);
           
        }
    }
}
