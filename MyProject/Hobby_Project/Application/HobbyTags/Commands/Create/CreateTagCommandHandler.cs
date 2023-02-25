using Application.HobbyTags.Queries;
using Application.Logger;
using Application.Repositories;
using AutoMapper;
using FluentValidation;
using Hobby_Project;
using HobbyProject.Application.Validators;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Tag tag = _mapper.Map<Tag>(command);  
                await _unitOfWork.TagRepository.Add(tag);
                await _unitOfWork.Save();
                return await Task.FromResult(tag);

            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
            
        }
    }
}
