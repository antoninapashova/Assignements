using Hobby_Project.Exceptions;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby_Project.Domain.Entity;
using Hobby_Project.Domain;

namespace Domain.Entity
{
      public class HobbyArticle : BaseEntity
      {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int HobbySubCategoryId { get; set; }
        public virtual User User { get; set; }
        public virtual HobbySubCategory HobbySubCategory { get; set; }
        public virtual ICollection<HobbyPhoto> HobbyPhoto { get; set; }
        public virtual ICollection<HobbyComment> HobbyComments { get; }
        public virtual ICollection<ArticleTag> HobbyTags { get; }
    }

}
