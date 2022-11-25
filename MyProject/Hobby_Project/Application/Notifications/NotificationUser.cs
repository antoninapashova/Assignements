using Domain.Interfaces;
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
        public string Username { get; }
        public void Notify(HobbyArticle hobbyArticle)
        {
            Console.WriteLine("A new hobby is added in the " + hobbyArticle.HobbySubCategory.Name + " subcategory");
        }
    }
}
