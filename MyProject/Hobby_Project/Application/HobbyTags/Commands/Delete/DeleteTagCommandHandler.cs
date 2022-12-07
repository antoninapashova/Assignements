using Application.Logger;
using Application.Repositories;
using Hobby_Project;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.HobbyTags.Commands.Delete
{
    internal class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        public DeleteTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Delete Tag command is null!");
                await _unitOfWork.TagRepository.DeleteAsync(command.Id);
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
