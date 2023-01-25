
using Domain.Entity;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbyComment : BaseEntity
    {

        public string CommentContent { get; set; }
        public int? UserId { get; set; }
        public int HobbyArticleId { get; set; }
        public string Username { get; set; }
        public HobbyArticle HobbyArticle { get; set; }
        public string Title { get; set; }
    }
}
