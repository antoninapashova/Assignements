using Microsoft.AspNetCore.Http;

namespace HobbyProject.Application.Hobby.Commands
{
    public class PhotoDTO
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
    }
}