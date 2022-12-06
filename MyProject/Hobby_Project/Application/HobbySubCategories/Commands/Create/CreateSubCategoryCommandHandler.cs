using Application.Logger;
using Application.Notifications;
using Application.Repositories;
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
        public async Task<int> Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create sub category command is null!");

                var hobbySubCategory = new HobbySubCategory(command.Name);
                await _repository.Add(hobbySubCategory);
                _hobbyPublisher.Publish(hobbySubCategory);
                return await Task.FromResult(hobbySubCategory.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
