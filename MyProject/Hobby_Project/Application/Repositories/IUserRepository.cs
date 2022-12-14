using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> Authenticate(string username, string password);
    }
}
