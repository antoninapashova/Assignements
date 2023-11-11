using Domain.Interfaces;
using Hobby_Project;

namespace Application.Notifications
{
    public class HobbyPublisher
    {
        private IList<ISubscriber> _subscribers;

        public HobbyPublisher(List<ISubscriber> subscribers)
        {
            this._subscribers = subscribers;
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Publish(SubCategory hobbySubCategory)
        {
            _subscribers.ToList().ForEach(s => s.Notify(hobbySubCategory));
        }
    }
}