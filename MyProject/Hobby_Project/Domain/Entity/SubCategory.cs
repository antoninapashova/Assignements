using Domain.Entity;

namespace Hobby_Project
{
    public class SubCategory : BaseCategory
    {
        public int HobbyCategoryId { get; set; }
        public virtual Category HobbyCategory { get; set; }
        public virtual ICollection<HobbyEntity> HobbyArticles { get; set; }
    }
}
