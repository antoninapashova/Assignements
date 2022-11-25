using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<HobbySubCategoryDTO> hobbySubCategories { get; set; }
    }
}
