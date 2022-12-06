using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ArticleTag
    {
        public int HobbyArticleId { get; set; }
        public int TagId { get; set; }
        public HobbyArticle HobbyArticle { get; set; }
        public Tag Tag { get; set; }
    }
}
