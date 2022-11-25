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
    internal class InMemoryUserRepository : IUserRepository
    {
        List<User> users = new();

        public void AddHobbyToUser(int userID, HobbyArticle hobby)
        {
            var user = isValid(userID);
            user.Hobbies.Add(hobby);
        
        }

        public void CreateUser(User user)
        {
            this.users.Add(user);
        }

        public void DeleteHobby(int userID, int hobbyID)
        {
            User user = isValid(userID);
            var hobby = user.Hobbies.FirstOrDefault(h => h.Id == hobbyID);
            if (hobby == null) throw new InvalidOperationException("The user does not have hobby with id: " + hobby);

            user.Hobbies.Remove(hobby);
        }

        public void DeleteUser(int userID)
        {
            var user = isValid(userID);

            this.users.Remove(user);
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

        public void UpdateUser(int userID, User user)
        {
            var searchedUser = isValid(userID);

            searchedUser.Username = user.Username;
            searchedUser.FirstName = user.FirstName;
            searchedUser.LastName = user.LastName;
            searchedUser.Email = user.Email;
            searchedUser.Age = user.Age;
            searchedUser.Hobbies = user.Hobbies;
        }

        private User isValid(int ID)
        {
            var user = users.FirstOrDefault(u => u.Id == ID);
            if (user == null) throw new InvalidOperationException("User with ID: " + ID + "does not exist");
            return user;
        }
    }
}
