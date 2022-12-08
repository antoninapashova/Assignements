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
        public int HobbyCategoryId { get; set; }
        public HobbyCategory HobbyCategory { get; set; }
        public ICollection<HobbyArticle> HobbyArticles { get; set; }

    }
}
