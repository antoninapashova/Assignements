using Application.Logger;
using Application.Repositories;
using MediatR;

namespace Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(command.Id);
                if (category == null) throw new NullReferenceException("Category not found!");

                _unitOfWork.CategoryRepository.Delete(category);
                await _unitOfWork.Save();

                return command.Id;
            }
            catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
