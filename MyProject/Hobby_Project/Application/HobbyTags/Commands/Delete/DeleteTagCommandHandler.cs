using Application.Logger;
using Application.Repositories;
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
               var tag = await _unitOfWork.TagRepository.GetByIdAsync(command.Id);

               if (tag == null) throw new NullReferenceException($"Tag with id: {command.Id} does not exist!"); 

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
    }
}
