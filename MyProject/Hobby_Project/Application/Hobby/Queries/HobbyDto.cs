using HobbyProject.Application.Hobby.Commands;

namespace Application.Hobby.Queries
{
    public class HobbyDto 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string HobbySubCategory { get; set; }
        public List<PhotoDTO> HobbyPhoto { get; set; }
        public List<HobbyTagDto> Tags { get; set; }
    }
}
