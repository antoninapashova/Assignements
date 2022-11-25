using Domain.Entity;
using Domain.Interfaces;

namespace Application.Notifications
{
    public class HobbyPublisher
    {
        Dictionary<int, List<ISubscriber>> dict_subscribers; //dict<subcategoryId, list<users>

        public HobbyPublisher(Dictionary<int, List<ISubscriber>> dict_subscribers)
        {
            this.dict_subscribers = dict_subscribers;
        }

        public void RemoveSubscriber(int subcategoryId, ISubscriber subscriber)
        {
            dict_subscribers[subcategoryId].Remove(subscriber);
        }

        public void AddSubscriber(int subcategoryId, ISubscriber subscriber)
        {
            dict_subscribers[subcategoryId].Add(subscriber);
        }

        public  void Publish(HobbyArticle hobby)
        {
            
            List<ISubscriber> subscribers = dict_subscribers[hobby.HobbySubCategory.Id]; // match Dicttionary

            subscribers.ForEach(s => s.Notify(hobby));
        }

    }
}