using Domain.Interfaces;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class Tag : BaseEntity, IEdit
    {
  
        public string Name{ get; set; }
        public User user { get; set; }
        public DateTime AddedOn { get; set; }

        public Tag(string name, User user)
        {
            Name = name;
            this.user = user;
            this.AddedOn = DateTime.Now;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void EditName()
        {
            this.Name.ToUpper();
        }
    }
}
