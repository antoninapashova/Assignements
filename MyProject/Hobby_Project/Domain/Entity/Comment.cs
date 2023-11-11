using Domain.Entity;
using Hobby_Project.Domain.Entity;
using HobbyProject.Domain.Entity;

namespace Hobby_Project
{
    public class Comment : BaseEntity
    {
        public string CommentContent { get; set; }
        public int HobbyArticleId { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual HobbyEntity HobbyArticle { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
