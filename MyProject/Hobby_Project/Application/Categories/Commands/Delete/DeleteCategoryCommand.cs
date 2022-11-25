using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
