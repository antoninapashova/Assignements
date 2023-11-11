using Application.Logger;
using Application.Repositories;
using AutoMapper;
using FluentValidation;
using HobbyProject.Application.Validators;
using HobbyProject.Domain.Entity;
using MediatR;

namespace Application.HobbyTags.Commands.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Tag>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<Tag> Handle(CreateTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var tagValidator = new TagValidator();
                await tagValidator.ValidateAndThrowAsync(command);
                await IsExist(command.Name);
                var tag = _mapper.Map<Tag>(command);  
                await _unitOfWork.TagRepository.Add(tag);
                await _unitOfWork.Save();

                return tag;
            }
            catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        private async Task IsExist(string name)
        {
            bool isExist = await _unitOfWork.TagRepository.CheckTagExists(name);
            if (isExist) throw new NullReferenceException($"Tag {name} already exists!");
        }
    }
}
