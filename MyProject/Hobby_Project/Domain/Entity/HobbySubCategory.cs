using Domain.Entity;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Hobby_Project
{
    public class HobbySubCategory : HobbyBaseCategory
    {
       
        public HobbySubCategory(int subCategoryId, string name)
        {
            Id = subCategoryId;
            Name = name;
        }

        public HobbySubCategory(string name)
        {
            Name = name;
            this.AddedOn = DateTime.Now;
           
         }

        public HobbySubCategory()
        {

        }

      
    }
}
