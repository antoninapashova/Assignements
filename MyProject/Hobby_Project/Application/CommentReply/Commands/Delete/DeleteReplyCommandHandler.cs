using Application.Logger;
using Application.Repositories;
using MediatR;

namespace HobbyProject.Application.CommentReply.Commands.Delete
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteReplyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var reply = await _unitOfWork.ReplyRepository.GetByIdAsync(command.Id);

                if (reply == null) throw new NullReferenceException($"Comment with id: {command.Id} does not exist!");

                _unitOfWork.ReplyRepository.Delete(reply);
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
