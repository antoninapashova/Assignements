using Domain.Interfaces;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class NotificationUser : ISubscriber
    {
        public int Id { get; set; }
        public string? Username { get; }

        //This method will notify all users that a new subcategory is added
        public void Notify(HobbySubCategory hobbySubCategory)
        {
            Console.WriteLine("A new subcategory is added");
        }
    }
}
