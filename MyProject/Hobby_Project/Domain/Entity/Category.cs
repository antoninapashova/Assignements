using Domain.Entity;

namespace Hobby_Project
{
    public class Category : BaseCategory
    {
        public virtual ICollection<SubCategory> HobbySubCategories { get; set;}
    }
}
