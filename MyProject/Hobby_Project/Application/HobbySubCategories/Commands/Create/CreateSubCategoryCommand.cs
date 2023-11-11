using Hobby_Project;
using MediatR;

namespace Application.HobbySubCategories.Commands.Create
{
    public class CreateSubCategoryCommand : IRequest<SubCategory>
    { 
        public int HobbyCategoryId { get; set; }
        public string Name { get; set; }
    }
}
