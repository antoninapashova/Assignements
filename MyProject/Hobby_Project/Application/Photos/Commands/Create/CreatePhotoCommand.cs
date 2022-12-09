using MediatR;

namespace HobbyProject.Application.Photos.Commands.Create
{
    public class CreatePhotoCommand : IRequest<int>
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public string PublicId { get; set; }
    }
}