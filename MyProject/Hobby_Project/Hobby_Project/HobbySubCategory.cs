using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbySubCategory : HobbyCategory
    {
        public HobbySubCategory(string name, DateTime addedOn) : base(name, addedOn)
        {
        }
     
    }
}
