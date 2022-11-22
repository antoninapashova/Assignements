using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    internal class Customer : ISubscriber<Discount>
    {
        public string Name { get; set; }
        public Customer(string name)
        {
            Name = name;
        }

        public void Notify(Discount discount)
        {
            Console.WriteLine("");
        }
    }
}
