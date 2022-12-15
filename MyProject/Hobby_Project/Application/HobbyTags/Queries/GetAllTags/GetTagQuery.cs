using HobbyProject.Application.HobbyTags.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Queries
{
    public class GetTagQuery : IRequest<IEnumerable<TagDto>>
    {
        public int Id { get; set; }

    }
}
