using Application.Logger;
using Application.Repositories;
using Hobby_Project;
using HobbyProject.Domain.Entity;
using MediatR;

namespace Application.HobbyTags.Commands.Delete
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await IsExist(command.Id);

               _unitOfWork.TagRepository.Delete(tag);
               await _unitOfWork.Save();

               return command.Id;
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task<Tag> IsExist(int id)
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(id);
            return tag ?? throw new NullReferenceException($"Tag with id: {id} doesn't exist!");
        }
    }
}
