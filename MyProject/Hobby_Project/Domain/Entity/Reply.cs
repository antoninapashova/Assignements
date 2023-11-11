using Hobby_Project;
using Hobby_Project.Domain.Entity;

namespace HobbyProject.Domain.Entity
{
    public class Reply : BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
