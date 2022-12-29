
using Application.Hobby.Commands.Create;
using Application.Logger;
using Application.Photos;
using Application.Repositories;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Entity;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (command == null) 
                    throw new NullReferenceException("Create photo command is null!");

                HobbyPhoto hobbyPhoto = _mapper.Map<HobbyPhoto>(command);
                await _unitOfWork.PhotoRepository.Add(hobbyPhoto);
                await _unitOfWork.Save();
                return await Task.FromResult(hobbyPhoto.Id);

            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }

        
    }
}
