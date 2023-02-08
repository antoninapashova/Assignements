
using Domain.Entity;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class Comment : BaseEntity
    {
        public string CommentContent { get; set; }
        public int HobbyArticleId { get; set; }
        public string Username { get; set; }
        public Hobby HobbyArticle { get; set; }
       
    }
}
