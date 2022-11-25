using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Delete
{
    public class DeleteSubCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public List<ISubscriber> Subscribers { get; set; } 
    }
}
