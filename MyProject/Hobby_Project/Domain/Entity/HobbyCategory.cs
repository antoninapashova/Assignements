using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Hobby_Project.Domain.Entity;
using Hobby_Project.Domain.Interfaces;

namespace Hobby_Project
{
    public class HobbyCategory :BaseEntity,  IPrint, IEdit
     {
        private string name;
        public DateTime AddedOn { get; set; }
        public List<HobbySubCategory> HobbySubCategories { get; set;}
        public HobbyCategory(string name, List<HobbySubCategory> hobbySubCategories)
        {
            Name = name;
            AddedOn = DateTime.Now;
            this.HobbySubCategories = hobbySubCategories;
        }

        public string Name
        {
            get { return name; }
            set
            {

                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
            }
        }

        public string PrintInfo()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("All info about the category");
            str.AppendLine("    Title: " + this.Name);
            return str.ToString();
        }

     
        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void EditName()
        {
            this.name = this.name.ToUpper();
            
        }
    }
}
