using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Hobby.Commands.Edit
{
    internal class EditHobbyCommandHandler : IRequestHandler<EditHobbyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        private IMapper _mapper;

        public EditHobbyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(EditHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Edit hobby command is null");
                HobbyArticle hobbyArticle = _mapper.Map<HobbyArticle>(command);
                await _unitOfWork.HobbyArticleRepository.UpdateAsync(command.Id,hobbyArticle);
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
