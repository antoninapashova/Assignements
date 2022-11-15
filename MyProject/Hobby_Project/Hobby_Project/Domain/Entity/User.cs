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
    public class User :BaseEntity
    {
       
        private string username;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private int age;
        public List<Hobby> Hobbies { get; set; }

        public User(string username, string firstName, string lastName, string email, int age)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Hobbies = new List<Hobby>();
        }


        public string Username {
            get { return username; }  
            set
            {
                if(value.Length<5)
                {
                    throw new ArgumentException("The username must be 5 or more characters!");
                }
                username = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <=0)
                {
                    throw new Exception("The age can not be negative or zero!");
                }
                age = value;
            }
        }

        public void AddNewHobby(Hobby hobby) => this.Hobbies.Add(hobby);
        public void RemoveHobby(Hobby hobby) =>this.Hobbies.Remove(hobby);
        public List<Hobby> findHobbyByHobbyCatgeory(HobbySubCategory hobbySubCategory) =>this.Hobbies.Where(x => x.HobbySubCategory.Name.Equals(hobbySubCategory.Name)).ToList();

        public void RemoveHobbyByName(String title)
        {
           Hobby hobby =  this.Hobbies.Where(x => x.Title.Equals(title)).First();
            if (hobby == null)
            {
                throw new HobbyDoesNotExistException("Hobby with title: " + title + " does not exist!");
            }

            RemoveHobby(hobby);
        }
       
        public void removeHobbiesByCategory(HobbySubCategory hobbySubCategory)
        {
            List<Hobby> hobbiesToRemove = findHobbyByHobbyCatgeory(hobbySubCategory);
            if(hobbiesToRemove == null)
            {
                throw new HobbyDoesNotExistException("There is now hobbies with " + hobbySubCategory.Name + " category");
            }


            foreach(var h in this.Hobbies)
            {
                foreach(var htr in hobbiesToRemove)
                {
                    if (h.ID == htr.ID)
                    {
                        this.Hobbies.Remove(h);
                    }
                }
            }
        }
    }
}
