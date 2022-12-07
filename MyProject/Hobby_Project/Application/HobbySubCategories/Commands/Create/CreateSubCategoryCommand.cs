using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Create
{
    internal class CreateSubCategoryCommand : IRequest<HobbySubCategory>
    { 
        public string Name { get; set; }

    }
}
