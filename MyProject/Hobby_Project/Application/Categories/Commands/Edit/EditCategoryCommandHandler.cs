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
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        private IMapper _mapper;

        public EditCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }
        public async Task<int> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Edit category command is null");
                HobbyCategory hobbyCategory = _mapper.Map<HobbyCategory>(command);
                await _unitOfWork.CategoryRepository.UpdateAsync(command.Id, hobbyCategory);
                await _unitOfWork.Save();
                return await Task.FromResult(command.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
