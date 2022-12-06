using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public abstract class HobbyBaseCategory : BaseEntity
    {
        public string Name { get; set; }
        
    }
}
