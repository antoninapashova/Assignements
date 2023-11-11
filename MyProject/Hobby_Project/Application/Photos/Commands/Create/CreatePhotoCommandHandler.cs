using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace HobbyProject.Application.Photos.Commands.Create
{
    public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public CreatePhotoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(CreatePhotoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create photo command is null!");

                var hobbyPhoto = _mapper.Map<Photo>(command);
                await _unitOfWork.PhotoRepository.Add(hobbyPhoto);
                await _unitOfWork.Save();

                return hobbyPhoto.Id;
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
