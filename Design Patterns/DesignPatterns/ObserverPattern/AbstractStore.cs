using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    internal abstract class AbstractStore<T>
    {
        private List<ISubscriber<T>> subscribers;

        public AbstractStore()
        {
            this.subscribers = new List<ISubscriber<T>>();
        }

        public void AddSubscriber(ISubscriber<T> subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void NewDiscount(T discount)
        {
            this.subscribers.ForEach(s => s.Notify(discount));
        }


    }
}
