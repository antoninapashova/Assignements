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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, HobbyCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        private IMapper _mapper;
        
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<HobbyCategory> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create category command is null!");
                HobbyCategory hobbyCategory = _mapper.Map<HobbyCategory>(command);
                await _unitOfWork.CategoryRepository.Add(hobbyCategory);
                await _unitOfWork.Save();
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

