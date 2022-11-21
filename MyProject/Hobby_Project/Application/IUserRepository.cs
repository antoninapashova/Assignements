using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        void AddHobbyToUser(int userID,Hobby hobby);
        void DeleteHobby(int userID, int hobbyID);
        void UpdateUser(int userID, User user);
        void DeleteUser(int userID);
        User GetUser (int userID);
        IEnumerable<User> GetAllUsers();

    }
}
