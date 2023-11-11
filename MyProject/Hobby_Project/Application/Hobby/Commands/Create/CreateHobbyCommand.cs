using HobbyProject.Application.Hobby.Commands;
using MediatR;

namespace Application.Hobby.Commands.Create
{
    public class CreateHobbyCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int HobbySubCategoryId { get; set; }
        public IEnumerable<CreateHobbyTagDto> Tags { get; set; }
        public IEnumerable<PhotoDTO> HobbyPhoto { get; set; }
    }
}
