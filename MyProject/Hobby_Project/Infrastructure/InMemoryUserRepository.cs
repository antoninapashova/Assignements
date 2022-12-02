using Application;
using Domain.Entity;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        List<User> users = new();

        public void AddHobbyToUser(int userID, HobbyArticle hobby)
        {
            var user =    isValid(userID);
            user.Hobbies.Add(hobby);
        }

        public void CreateUser(User user)
        {
            this.users.Add(user);
            user.Id = users.Count;
        }

        public void DeleteHobby(int userID, int hobbyID)
        {
            User user = isValid(userID);
            var hobby = user.Hobbies.FirstOrDefault(h => h.Id == hobbyID);
            if (hobby == null) throw new InvalidOperationException("The user does not have hobby with id: " + hobby);

            user.Hobbies.Remove(hobby);
        }

        public User DeleteUser(int userID)
        {
            var user = isValid(userID);

            this.users.Remove(user);
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.users;
        }

        public User GetUser(int userID)
        {
            var user = isValid(userID);
            return user;
        }

        public void UpdateUser(int userID, string username, string firstName, string lastName, string email)
        {
            var searchedUser = isValid(userID);
            searchedUser.Username = username;
            searchedUser.FirstName = firstName;
            searchedUser.LastName = lastName;
            searchedUser.Email = email;
        }

        private User isValid(int Id)
        {
            if (Id <= 0) throw new NullReferenceException("Id must be positive!");
            var user = users.FirstOrDefault(u => u.Id == Id);
            if (user == null) throw new InvalidOperationException("User with ID: " + Id + "does not exist");
            return user;
        }
    }
}
