using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using MediatR;
using HobbyProject.Application.Validators;
using FluentValidation;

namespace Application.Hobby.Commands.Create
{
    public class CreateHobbyCommandHandler : IRequestHandler<CreateHobbyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateHobbyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create hobby command is null!");

                var hobbyValidator = new HobbyArticleValidator();
                await hobbyValidator.ValidateAndThrowAsync(command);

                var hobby = _mapper.Map<HobbyEntity>(command);
                await _unitOfWork.HobbyArticleRepository.Add(hobby);
                hobby.HobbyPhoto.Clear();
                await _unitOfWork.Save();
                
                foreach(var p in command.HobbyPhoto)
                {
                    var photo = _mapper.Map<Photo>(p);
                    photo.HobbyArticleId = hobby.Id;
                    await _unitOfWork.PhotoRepository.Add(photo);
                    await _unitOfWork.Save();
                }

                return await Task.FromResult(hobby.Id);
            }
            catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
