using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class HobbyPhoto : BaseEntity
    {
        public int HobbyArticleId { get; set; }
        public HobbyArticle HobbyArticle { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string PublicId { get; set; }
    }
}
