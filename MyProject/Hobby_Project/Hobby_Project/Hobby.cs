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
        public SubCategoryHobby SubCategoryHobby { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }

        public Hobby()
        {
        }

        public Hobby( string title, SubCategoryHobby subCategoryHobby, string description)
        {
           
            this.title = title;
            this.subCategoryHobby = subCategoryHobby;
            this.description = description;
        }

        public string editDescription()
        {
            return description.ToUpper();
        }

        public string editDescription(string addationDescription)
        {
            return string.Format(this.description + " " + addationDescription);
        }

        public string printInfo()
        {
          StringBuilder str = new StringBuilder();
            str.AppendLine("All info about the hobby");
            str.AppendLine("    Title: "+ this.title);
            str.AppendLine("    Description: " + this.description);
            str.AppendLine("    Date and time: " + this.addedOn);
            str.AppendLine("    Subcategory: " + this.subCategoryHobby.Name);
            return str.ToString();
        }
    }
}
