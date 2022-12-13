
using Application.Photos;
using CloudinaryDotNet;
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
    public class CreatePhotoCommandHandler
        //: IRequestHandler<CreatePhotoCommand, int>
    {
        
        private CloudinarySettings _settings;
        private Cloudinary _cloudinary;

        public CreatePhotoCommandHandler()
        {
              //_settings = Configuration.GetSection("CloudinarySettings");
                //.GetSection<CloudinarySettings>();
            Account account = new Account(_settings.CloudName, _settings.ApiKey, _settings.ApiSecret);

            _cloudinary = new Cloudinary();
        }
        /*
        public Task<int> Handle(CreatePhotoCommand request, CancellationToken cancellationToken)
        {
            
        }
        */
    }
}
