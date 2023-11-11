namespace HobbyProject.Application.Hobby.Dto
{
    public class HobbyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string HobbySubCategory { get; set; }
        public IList<PhotoDTO> HobbyPhoto { get; set; }
        public IList<HobbyTagDto> Tags { get; set; }
    }
}
