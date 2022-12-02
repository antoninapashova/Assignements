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
    internal class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, int>
    {
        private readonly ISubCategoryRepository _repository;
        private readonly HobbyPublisher _hobbyPublisher;
        private ILog _log;
        public CreateSubCategoryCommandHandler(ISubCategoryRepository repository, HobbyPublisher hobbyPublisher)
        {
            _repository = repository;
            _hobbyPublisher = hobbyPublisher;
            _log = SingletonLogger.Instance;
        }
        public Task<int> Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create sub category command is null!");

                var hobbySubCategory = new HobbySubCategory(command.Name);
                _repository.AddSubCategory(hobbySubCategory);
                _hobbyPublisher.Publish(hobbySubCategory);
                return Task.FromResult(hobbySubCategory.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
        }
    }
}
