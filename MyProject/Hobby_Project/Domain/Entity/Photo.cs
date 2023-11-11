using Hobby_Project.Domain.Entity;

namespace Domain.Entity
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; } 
        public int HobbyArticleId { get; set; }
        public HobbyEntity HobbyArticle { get; set; }
    }
}
