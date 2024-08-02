using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Hobby.Commands.Edit
{
    public class UpdateHobbyCommandHandler : IRequestHandler<UpdateHobbyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public UpdateHobbyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(UpdateHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Edit hobby command is null");

                var hobbyArticle = _mapper.Map<HobbyEntity>(command);
                _unitOfWork.HobbyArticleRepository.Update(hobbyArticle);
                await _unitOfWork.Save();

                return command.Id;
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
