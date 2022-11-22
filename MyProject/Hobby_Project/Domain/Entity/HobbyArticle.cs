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
        private string title;
        public string Description { get; set; }

        private HobbySubCategory hobbySubCategory;
        public DateTime AddedOn { get; set; }
        public List<HobbyComment> Comments { get; set; }
        public List<Tag> Tags { get; set; }

        public HobbyArticle(string title, string description, HobbySubCategory hobbySubCategory, List<HobbyComment> comments, List<Tag> tags)
        {
            Title = title;
            Description = description;
            HobbySubCategory = hobbySubCategory;
            AddedOn = DateTime.Now;
            Comments = comments;
            Tags = tags;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("The title should not be NULL!");
                }

                title = value;
            }
        }
        public HobbySubCategory HobbySubCategory
        {
            get { return hobbySubCategory; }
            set
            {
                if (value == null)
                {
                    throw new HobySubCategoryDoesNotSetException("The Sub category of the hoby is not set!");
                }
                hobbySubCategory = value;
            }
        }

 
    }

}
