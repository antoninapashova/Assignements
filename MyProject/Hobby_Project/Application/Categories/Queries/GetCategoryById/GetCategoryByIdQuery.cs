using HobbyProject.Application.Categories.Queries.GetAllCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Categories.Queries.GetCategoryById
{
     public class GetCategoryByIdQuery : IRequest<CategoryVm>
    {
        public int Id { get; set; }
       
        
    }
}
