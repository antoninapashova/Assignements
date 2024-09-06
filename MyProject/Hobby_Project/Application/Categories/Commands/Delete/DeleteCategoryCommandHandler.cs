using Application.Logger;
using Application.Repositories;
using Hobby_Project;
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
                var category = await IsExist(command.Id);

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

        private async Task<Category> IsExist(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return category ?? throw new NullReferenceException("Category not found!");
        }
    }
}
