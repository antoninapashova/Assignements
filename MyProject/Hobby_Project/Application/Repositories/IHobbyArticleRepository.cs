using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IHobbyArticleRepository : IRepository<Domain.Entity.HobbyEntity>
    {
        Task<IEnumerable<Domain.Entity.HobbyEntity>> GetHobbyArticlesByUserId(int id);
        Task<IEnumerable<Domain.Entity.HobbyEntity>> GetHobbyArticlesByUsername(string username);
    }
}
