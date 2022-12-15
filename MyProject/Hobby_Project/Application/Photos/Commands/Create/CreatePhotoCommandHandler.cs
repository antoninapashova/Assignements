
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
        private CloudinarySettings _settings;
        private Cloudinary _cloudinary;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;

        public CreatePhotoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            Account account = new Account(_settings.CloudName, _settings.ApiKey, _settings.ApiSecret);
            _cloudinary = new Cloudinary(account);
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(CreatePhotoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                int v = UploadPhoto(command);
                HobbyPhoto hobbyPhoto = _mapper.Map<HobbyPhoto>(command);
                await _unitOfWork.PhotoRepository.Add(hobbyPhoto);
                await _unitOfWork.Save();
                return await Task.FromResult(hobbyPhoto.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }

        private int UploadPhoto(CreatePhotoCommand command)
        {
            var file = command.File;

            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            command.Url = uploadResult.Url.ToString();
            command.PublicId = uploadResult.PublicId;

            var photo = new HobbyPhoto
            {
                Url = command.Url,
                Description = command.Description,
                PublicId = command.PublicId,
            };

            return photo.Id;
        }
    }
}
