using Hobby_Project;

namespace HobbyProject.Application.Users.Queries.GetAllUsers
{
    public class HobbyArticleDTO
    {

        public string Title { get; set; }
        public string Description { get; set; }

        public HobbySubCategory HobbySubCategory;
        public DateTime AddedOn { get; set; }
        public List<HobbyComment> Comments { get; set; }
        public List<Tag> Tags { get; set; }
    }
}