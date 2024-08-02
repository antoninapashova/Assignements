using Application.Logger;
using Application.Repositories;
using MediatR;

namespace Application.Comments.Commands.Delete
{
    public  class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _unitOfWork.CommentRepository.GetByIdAsync(command.Id);

                if (entity == null) throw new NullReferenceException($"Comment with id: {command.Id} does not exist!");
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
