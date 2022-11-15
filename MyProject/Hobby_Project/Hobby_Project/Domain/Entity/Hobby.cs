
using Hobby_Project.Domain.Entity;
using Hobby_Project.Domain.Interfaces;
using Hobby_Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class Hobby :BaseEntity, IPrint
    {
        private string title;
        public string Description { get; set; }

        private HobbySubCategory hobbySubCategory;
        public DateTime AddedOn { get; set; }
        public List<HobbyComment> Comments { get; set; }
        public List<Tag> Tags { get; set; }

        public Hobby(string title, string description, HobbySubCategory hobbySubCategory)
        {
            Title = title;
            Description = description;
            HobbySubCategory = hobbySubCategory;
            AddedOn = DateTime.Now;
            Comments = new List<HobbyComment>();
            Tags = new List<Tag>();
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

        public Guid Id { get; internal set; }

        public string EditDescription() => Description.ToUpper();

        public string EditDescription(string addationDescription) => string.Format(this.Description + " " + addationDescription);
        
        public void AddComment(HobbyComment hobbyComment) =>this.Comments.Add(hobbyComment);
        
        public void AddTag(Tag tag)=>this.Tags.Add(tag);
        public void changeSubCategory(HobbySubCategory hobbySubCategory) => this.HobbySubCategory = hobbySubCategory;
       
        
        public string PrintInfo()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("All info about the hobby");
            str.AppendLine("    Title: "+ this.title);
            str.AppendLine("    Description: " + this.Description);
            str.AppendLine("    Date and time: " + this.AddedOn);
            return str.ToString();
        }
    }
}
