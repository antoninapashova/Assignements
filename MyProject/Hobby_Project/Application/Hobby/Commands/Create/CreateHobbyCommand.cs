using Application.Comments.Commands.Create;
using Application.Hobby.Queries;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Hobby.Commands;
using HobbyProject.Application.HobbyTags.Queries;
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
        public string Username { get; set; }
        public int HobbySubCategoryId { get; set; }
        public List<CreateHobbyTagDto> Tags { get; set; }
        public List<PhotoDTO> HobbyPhoto { get; set; }

    }
}
