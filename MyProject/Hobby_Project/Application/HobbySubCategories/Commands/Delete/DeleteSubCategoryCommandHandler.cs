using Application.Logger;
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

        public DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public Task<int> Handle(DeleteSubCategoryCommand command, CancellationToken cancellationToken)
        {
            _subCategoryRepository.DeleteSubCategory(command.Id);
            SingletonLogger.Instance.LogMessage("delete", "Subcategory with Id " + command.Id + " is deleted");
            return Task.FromResult(command.Id);

        }
    }
}
