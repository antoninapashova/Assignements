using Application.Logger;
using Application.Notifications;
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
        private readonly HobbyPublisher _hobbyPublisher;

        public CreateSubCategoryCommandHandler(ISubCategoryRepository repository, HobbyPublisher hobbyPublisher)
        {
            _repository = repository;
            _hobbyPublisher = hobbyPublisher;
        }

        Task<int> IRequestHandler<CreateSubCategoryCommand, int>.Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            var hobbySubCategory = new HobbySubCategory(command.Name);
            _repository.AddSubCategory(hobbySubCategory);
            _hobbyPublisher.Publish(hobbySubCategory);
            SingletonLogger.Instance.LogMessage("create", "Subcategory with name " + hobbySubCategory.Name + " is added");
            return Task.FromResult(hobbySubCategory.Id);
        }
    }
}
