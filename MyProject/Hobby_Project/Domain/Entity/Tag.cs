using Domain.Entity;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Domain.Entity
{
    public class Tag : BaseEntity 
    {
        public string Name { get; set; }
        public virtual ICollection<HobbyEntity> HobbyArticles { get; set; }

    }
}
