using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Create
{
    internal class CreateSubCategoryCommand : IRequest<int>
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }

    }
}
