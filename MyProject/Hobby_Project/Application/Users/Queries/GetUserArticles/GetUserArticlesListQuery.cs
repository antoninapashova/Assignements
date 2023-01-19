using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Users.Queries.GetUserArticles
{
    public class GetUserArticlesListQuery : IRequest<IEnumerable<HobbyArticleDTO>>
    {
        public int Id { get; set; }
    }
}
