using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Logger;
using System.Reflection.Emit;
using Application.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using AutoMapper;

namespace Application.Categories.Commands.Edit
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Category>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        private readonly IMapper _mapper;

        public EditCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<Category> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) 
                    throw new NullReferenceException("Edit category command is null");

                Category hobbyCategory = _mapper.Map<Category>(command);
                Category editeHobbyCategory = await _unitOfWork.CategoryRepository.Update(hobbyCategory);
                await _unitOfWork.Save();

                return await Task.FromResult(editeHobbyCategory);

            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
