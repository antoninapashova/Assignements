using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IHobbyArticleRepository : IRepository<HobbyArticle>
    {
        Task<IEnumerable<HobbyArticle>> GetHobbyArticlesByUserId(int id);
        Task<IEnumerable<HobbyArticle>> GetHobbyArticlesByUsername(string username);
    }
}
