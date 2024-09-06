using Application.Logger;
using Application.Repositories;
using Hobby_Project;
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
                var subCategory = await IsExist(command.Id);

                _unitOfWork.SubCategoryRepository.Delete(subCategory);
                await _unitOfWork.Save();

                return command.Id;
            }
            catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task<SubCategory> IsExist(int id)
        {
            var subCategory = await _unitOfWork.SubCategoryRepository.GetByIdAsync(id);
            return subCategory ?? throw new NullReferenceException($"Hobby with id: {id} does not exist!");
        }
    }
}
