using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Create
{
    public class CreateSubCategoryCommand : IRequest<HobbySubCategory>
    { 
        public int HobbyCategoryId { get; set; }
        public string Name { get; set; }

    }
}
