
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbyComment :BaseEntity
    {
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public User User { get; set; }
        public DateTime AddedOn { get; set; }

        public HobbyComment(string title, string commentContent, User user)
        {
            Title = title;
            CommentContent = commentContent;
            User = user;
            AddedOn = DateTime.Now;
        }

        
    }
}
