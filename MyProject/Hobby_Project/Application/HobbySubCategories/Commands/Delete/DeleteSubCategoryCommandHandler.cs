using Application.Logger;
using Application.Repositories;
using MediatR;

namespace Application.HobbySubCategories.Commands.Delete
{
    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        public DeleteSubCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(command.Id);

                if (subCategory == null) throw new NullReferenceException($"SubCategory with id: {command.Id} does not exist!");

                await _unitOfWork.SubCategoryRepository.DeleteAsync(command.Id);
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
