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
       
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set;}
        public List<HobbyArticle> Hobbies { get; set; }

        public User(string username, string firstName, string lastName, string email, int age, List<HobbyArticle> hobbies)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Hobbies = hobbies;
        }

        public User(int id,string username, string firstName, string lastName, string email, int age, List<HobbyArticle> hobbies)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Hobbies = hobbies;
        }
    }
}
