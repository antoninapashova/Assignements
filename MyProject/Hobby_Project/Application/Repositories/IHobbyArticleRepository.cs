using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IHobbyArticleRepository : IRepository<Domain.Entity.Hobby>
    {
        Task<IEnumerable<Domain.Entity.Hobby>> GetHobbyArticlesByUserId(int id);
        Task<IEnumerable<Domain.Entity.Hobby>> GetHobbyArticlesByUsername(string username);
    }
}
