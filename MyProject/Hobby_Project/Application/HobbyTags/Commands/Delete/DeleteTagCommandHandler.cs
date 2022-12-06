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
        private readonly ITagRepository _tagRepository;
        private ILog _log;
        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Delete Tag command is null!");
                Tag tag = await _tagRepository.GetByIdAsync(command.Id);
                await _tagRepository.DeleteAsync(tag.Id);
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
