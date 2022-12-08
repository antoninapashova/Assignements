using Domain.Entity;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class Tag : BaseEntity
    {
        public string Name{ get; set; }
        public ICollection<ArticleTag> HobbyArticles{ get; set; }

    }
}
