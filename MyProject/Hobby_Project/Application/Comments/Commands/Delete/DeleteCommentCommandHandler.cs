using Application.Logger;
using Application.Repositories;
using Hobby_Project;
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
                var comment = await IsExist(command.Id);

                _unitOfWork.CommentRepository.Delete(comment);
                await _unitOfWork.Save();

                return command.Id;
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task<Comment> IsExist(int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            return comment ?? throw new NullReferenceException($"Comment with id: {id} does not exist!");
        }
    }
}
