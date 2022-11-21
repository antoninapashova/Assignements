using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Commands
{
    public class CreateTagCommand : IRequest<int>
    {
        public int ID { get; set; }
        public  string Name { get; set; }
    }
}
