using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Queries
{
   public class GetTagsListQuery : IRequest<IEnumerable<TagListVm>>
    {
        
        public string Name { get; set; }

    }
}
