using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class SubCategoryHobby : CommonProperties, IPrint
    {  
        public CategoryHobby categoryHobby { get; set; }
        public SubCategoryHobby(string name, DateTime addedOn, CategoryHobby categoryHobby) : base(name, addedOn)
        {
            this.categoryHobby = categoryHobby;
        }

        public override void editName()
        {
            this.Name = this.Name.ToUpper();
        }

        public override void changeName(string newName)
        {
            this.Name = newName;
        }

        public string printInfo()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("All info about the sub category");
            str.AppendLine("    Title: " + this.Name);

            return str.ToString();
        }
    }
}
