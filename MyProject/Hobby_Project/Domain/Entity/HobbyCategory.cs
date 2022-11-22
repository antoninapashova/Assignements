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
    public class HobbyCategory :BaseEntity
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

       
    }
}
