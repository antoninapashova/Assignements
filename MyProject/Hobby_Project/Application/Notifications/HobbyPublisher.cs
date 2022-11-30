using Domain.Entity;
using Domain.Interfaces;
using Hobby_Project;

namespace Application.Notifications
{
    public class HobbyPublisher
    {
        private List<ISubscriber> subscribers;

        public HobbyPublisher(List<ISubscriber> subscribers)
        {
            this.subscribers = subscribers;
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void AddSubscriber( ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public  void Publish(HobbySubCategory hobbySubCategory)
        {
            subscribers.ForEach(s => s.Notify(hobbySubCategory));
        }

    }
}