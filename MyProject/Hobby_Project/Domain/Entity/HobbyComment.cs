
using Domain.Entity;
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
        public HobbyComment()
        {
        }

        public HobbyComment(string title, string commentContent, User user)
        {
            Title = title;
            CommentContent = commentContent;
            User = user;
        }

        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int HobbyArticleId { get; set; }
        public User User { get; set; }
        public HobbyArticle HobbyArticle { get; set; }
        public string Title { get; }
    }
}
