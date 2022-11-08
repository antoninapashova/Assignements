using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class Hobby : IPrint
    {
        private string title;
        
        public SubCategoryHobby SubCategoryHobby { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }

    
        public Hobby(string title, SubCategoryHobby subCategoryHobby, string description, DateTime addedOn)
        {
            Title = title;
            SubCategoryHobby = subCategoryHobby;
            Description = description;
            AddedOn = addedOn;
        }
        
        public string Title
        {
            get { return title; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    title = value;
                }
            }
        }

        public string editDescription()
        {
            return Description.ToUpper();
        }

        public string editDescription(string addationDescription)
        {
            return string.Format(this.Description + " " + addationDescription);
        }

        public string printInfo()
        {
          StringBuilder str = new StringBuilder();
            str.AppendLine("All info about the hobby");
            str.AppendLine("    Title: "+ this.title);
            str.AppendLine("    Description: " + this.Description);
            str.AppendLine("    Date and time: " + this.AddedOn);
            str.AppendLine("    Subcategory: " + this.SubCategoryHobby.Name);
            return str.ToString();
        }
    }
}
