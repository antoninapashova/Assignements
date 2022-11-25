using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Create
{
    public class CreateHobbyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public HobbySubCategoryDTO HobbySubCategory;
        public List<HobbyCommentDTO> Comments { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
