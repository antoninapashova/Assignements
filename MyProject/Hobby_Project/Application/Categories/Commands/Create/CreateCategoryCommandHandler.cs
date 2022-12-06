using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Categories.Commands.Create
{
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, HobbyCategory>
    {
        private readonly ICategoryRepository _repository;
        private ILog _log;
        private IMapper _mapper;
        
        public CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<HobbyCategory> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create category command is null!");

                HobbyCategory hobbyCategory = await _repository.Add(_mapper.Map<HobbyCategory>(command));
                return await Task.FromResult(hobbyCategory);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult<HobbyCategory>(null);
            }
        }
    }
}
//2 unit tests with mock repository
  // -- test for throwing RIGHT exception with null command
  // -- test for checking Assert.equal(1,hobbyCategoryId)
