using Hobby_Project;
using Hobby_Project.Domain.Entity;
using HobbyProject.Domain.Entity;

namespace Domain.Entity
{
    public class HobbyEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int HobbySubCategoryId { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual SubCategory HobbySubCategory { get; set; }
        public virtual ICollection<Photo> HobbyPhoto { get; set; }
        public virtual ICollection<Comment> HobbyComments { get; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
