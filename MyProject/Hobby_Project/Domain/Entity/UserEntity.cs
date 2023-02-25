using Domain.Entity;
using Hobby_Project.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Domain.Entity
{
    public class UserEntity : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
     
        public virtual ICollection<HobbyEntity> Hobbies { get; set; }

    }
}
