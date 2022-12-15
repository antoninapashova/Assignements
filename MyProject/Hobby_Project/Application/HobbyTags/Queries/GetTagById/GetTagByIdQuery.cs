using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.HobbyTags.Queries.GetTagById
{
    public class GetTagByIdQuery : IRequest<TagDto>
    {
        public int Id { get; set; }
    }
}
