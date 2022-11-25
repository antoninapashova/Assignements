using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Delete
{
    public class DeleteHobbyCommand : IRequest<int>
    {
        public int Id { get; }
     
    }
}
