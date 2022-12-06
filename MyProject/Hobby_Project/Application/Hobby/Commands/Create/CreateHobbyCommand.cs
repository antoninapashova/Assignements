using Application.Comments.Commands.Create;
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
        public string Title { get; set; }
        public string Description { get; set; }

        public HobbySubCategoryDTO HobbySubCategory;
        public List<TagDTO> Tags { get; set; }
        public UserDTO User { get; set; }
    }
}
