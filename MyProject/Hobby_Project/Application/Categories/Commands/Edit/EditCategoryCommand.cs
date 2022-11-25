using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Edit
{
    public class EditCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
