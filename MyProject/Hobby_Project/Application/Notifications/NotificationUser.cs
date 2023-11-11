using Domain.Interfaces;
using Hobby_Project;

namespace Domain.Entity
{
    public class NotificationUser : ISubscriber
    {
        public int Id { get; set; }
        public string Username { get; }

        public void Notify(SubCategory hobbySubCategory)
        {
        }
    }
}
