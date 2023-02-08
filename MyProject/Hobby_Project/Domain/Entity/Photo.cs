using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }
        public string PublicId { get; set; } 
        public int HobbyArticleId { get; set; }
        public Hobby HobbyArticle { get; set; }
    }
}
