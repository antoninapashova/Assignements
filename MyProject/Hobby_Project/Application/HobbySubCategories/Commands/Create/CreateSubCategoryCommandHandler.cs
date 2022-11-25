using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Create
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, int>
    {
        private readonly ISubCategoryRepository _repository;

        public CreateSubCategoryCommandHandler(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        Task<int> IRequestHandler<CreateSubCategoryCommand, int>.Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            var hobbySubCategory = new HobbySubCategory(command.Name);
            _repository.AddSubCategory(hobbySubCategory);

            return Task.FromResult(hobbySubCategory.Id);
        }
    }
}
