using Domain.Entity;
using Hobby_Project.Domain.Entity;

namespace HobbyProject.Domain.Entity
{
    public class Tag : BaseEntity 
    {
        public string Name { get; set; }
        public virtual ICollection<HobbyEntity> HobbyArticles { get; set; }
    }
}
