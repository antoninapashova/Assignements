using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Queries
{
    public class GetHobbyListQuery : IRequest<IEnumerable<HobbyListVm>>
    {
        
        public string Title { get; set; }
        public string Description { get; set; }

        public HobbySubCategory hobbySubCategory;
        public List<HobbyCommentDTO> Comments { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
