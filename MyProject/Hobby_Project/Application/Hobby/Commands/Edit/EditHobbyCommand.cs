using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Edit
{
    internal class EditHobbyCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
    }
}
