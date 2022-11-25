using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class Tag : BaseEntity
    {
        public string Name{ get; set; }
        public DateTime AddedOn { get; set; }

        public Tag(string name)
        {
            Name = name;
           
            this.AddedOn = DateTime.Now;
        }

    }
}
