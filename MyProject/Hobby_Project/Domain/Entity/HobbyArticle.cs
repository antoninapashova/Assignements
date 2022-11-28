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

        public HobbySubCategory HobbySubCategory { get; set; }
        public DateTime AddedOn { get; set; }
        public List<HobbyComment> Comments { get; set; }
        public List<Tag> Tags { get; set; }

        public HobbyArticle(string title, string description, HobbySubCategory hobbySubCategory, 
            List<HobbyComment> comments, List<Tag> tags)
        {
            Title = title;
            Description = description;
            HobbySubCategory = hobbySubCategory;
            AddedOn = DateTime.Now;
            Comments = comments;
            Tags = tags;
        }

        public HobbyArticle(int id, string title, string description, HobbySubCategory hobbySubCategory, 
            List<HobbyComment> comments, List<Tag> tags)
        {
            Id = id;
            Title = title;
            Description = description;
            HobbySubCategory = hobbySubCategory;
            AddedOn = DateTime.Now;
            Comments = comments;
            Tags = tags;
         
        }
    }

}
