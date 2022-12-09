using Application.Cloudinary;
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
        public IConfiguration Configuration;
        private CloudinarySettings _settings;
        private Cloudinary _cloudinary;
        public CreatePhotoCommandHandler(IConfiguration configuration)
        {
            Configuration = configuration;
            //_settings = Configuration.GetSection("CloudibnarySettings");
                //.GetSection<CloudinarySettings>();
            Account account = new Account(_settings.CloudName, _settings.ApiKey, _settings.ApiSecret);

            _cloudinary = new Cloudinary();
            
        }


        /*
        private public Task<int> Handle(CreatePhotoCommand command, CancellationToken cancellationToken)
        {
            
        }
        */
    }
}
