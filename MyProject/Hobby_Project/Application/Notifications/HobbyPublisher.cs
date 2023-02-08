using Domain.Entity;
using Domain.Interfaces;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries;

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

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Publish(SubCategory hobbySubCategory)
        {
            subscribers.ForEach(s => s.Notify(hobbySubCategory));
        }

    }
}