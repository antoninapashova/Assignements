using Domain.Entity;
using Hobby_Project.Domain.Entity;
using Hobby_Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class User : BaseEntity
    {
        public User(){}

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set;}
        public ICollection<HobbyArticle> Hobbies { get; set; }
        public ICollection<HobbyComment> Comments { get; set; }
    }
}
