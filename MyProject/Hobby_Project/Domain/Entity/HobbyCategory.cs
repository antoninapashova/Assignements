using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby_Project.Domain.Entity;
using Hobby_Project.Domain;
using Domain.Entity;

namespace Hobby_Project
{
    public class HobbyCategory : HobbyBaseCategory
     {
        public ICollection<HobbySubCategory> HobbySubCategories { get; set;}
  
    }
}
