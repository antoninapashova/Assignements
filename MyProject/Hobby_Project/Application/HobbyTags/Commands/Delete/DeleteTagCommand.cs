using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Commands.Delete
{
    public class DeleteTagCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
