using Domain.Entity;
using Hobby_Project;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Domain.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiredTime { get; set; }

        public virtual ICollection<HobbyEntity> Hobbies { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
