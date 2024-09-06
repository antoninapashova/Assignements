using Application.Logger;
using Application.Repositories;
using AutoMapper;
using FluentValidation;
using Hobby_Project;
using HobbyProject.Application.Validators;
using MediatR;

namespace Application.HobbySubCategories.Commands.Create
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, SubCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateSubCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper= mapper;
        }

        public async Task<SubCategory> Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await IsExist(command.Name);
                await ValidateCommand(command);

                var hobbySubCategory = _mapper.Map<SubCategory>(command);
                await _unitOfWork.SubCategoryRepository.Add(hobbySubCategory);
                await _unitOfWork.Save();

                return hobbySubCategory;
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task IsExist(string name)
        {
            bool isSubcategoryExists = await _unitOfWork.SubCategoryRepository.CheckSubCategoryExists(name);
            if (isSubcategoryExists) throw new NullReferenceException($"The subcategory {name} already exists!");
        }

        private static async Task ValidateCommand(CreateSubCategoryCommand command)
        {
            var subCategoryValidator = new SubCategoryValidator();
            await subCategoryValidator.ValidateAndThrowAsync(command);
        }
    }
}
