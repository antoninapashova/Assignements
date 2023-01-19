using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<HobbyCategory>
    {
        [NotNull]
        public string Name { get; set; }
      
    }
}
