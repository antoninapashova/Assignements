
using Domain.Entity;
using Hobby_Project.Domain.Entity;
using HobbyProject.Domain.Entity;
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
        public UserEntity User { get; set; }
        public HobbyEntity HobbyArticle { get; set; }
       
    }
}
