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
        public User User { get; set; }
        public HobbySubCategory HobbySubCategory { get; set; }
       // public int PhotoId { get; set; }
        //public HobbyPhoto HobbyPhoto { get; set; }
        public ICollection<HobbyComment> HobbyComments { get; }
        public ICollection<ArticleTag> HobbyTags { get; }
    }

}
