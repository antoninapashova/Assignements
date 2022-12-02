using Application.Logger;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Create
{
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _repository;
        private ILog _log;
        
        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
            _log = SingletonLogger.Instance;
        }

        public Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create category comand is null!");

                List<HobbySubCategory> subCategories = new List<HobbySubCategory>();
            
                var hobbyCategory = new HobbyCategory(command.Name, subCategories);
                _repository.CreateCategory(hobbyCategory);
                return Task.FromResult(hobbyCategory.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return Task.FromResult(0);
            }
            
        }
    }
}
//2 unit tests with mock repository
  // -- test for throwing RIGHT exception with null command
  // -- test for checking Assert.equal(1,hobbyCategoryId)
