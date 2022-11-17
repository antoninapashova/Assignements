using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbySubCategory 
    {
        public string Name { get; set; }
        public DateTime AddedOn { get; set; }

        public HobbySubCategory(string name)
        {
            Name = name;
            this.AddedOn = DateTime.Now;
        }
    }
}
