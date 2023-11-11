using Hobby_Project;

namespace Domain.Interfaces
{
    public interface ISubscriber
    {
        public int Id { get; set; }
        void Notify(SubCategory hobbySubCategory);
    }
}
