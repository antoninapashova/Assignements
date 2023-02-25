using Hobby_Project;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Commands.Create
{
    public class CreateTagCommand : IRequest<Tag>
    {
        public string Name { get; set; }
    }
}
