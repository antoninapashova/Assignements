using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class CategoryHobby : CommonProperties, IPrint
    {
        public CategoryHobby(string name, DateTime addedOn) : base(name, addedOn)
        {
        }

        public override void changeName(string newName)
        {
            this.Name = newName;
        }

        public override void editName()
        {
            this.Name = this.Name.ToUpper();
        }

        public string printInfo()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("All info about the category");
            str.AppendLine("    Title: " + this.Name);
            
            return str.ToString();
        }
    }
}
