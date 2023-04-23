using Application.Logger;
using Application.Repositories;
using AutoMapper;
using FluentValidation;
using Hobby_Project;
using HobbyProject.Application.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        private readonly IMapper _mapper;
        
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<Category> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create category command is null!");
                var tagValidator = new CategoryValidator();
                await tagValidator.ValidateAndThrowAsync(command);
                await IsExist(command.Name);
                Category hobbyCategory = _mapper.Map<Category>(command);
                await _unitOfWork.CategoryRepository.Add(hobbyCategory);
                await _unitOfWork.Save();

                return await Task.FromResult(hobbyCategory);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task IsExist(string name)
        {
            bool isExist = await _unitOfWork.CategoryRepository.CheckCategoryExists(name);
            if (isExist) throw new NullReferenceException($"The category {name} already exists!");
        }
    }
}

