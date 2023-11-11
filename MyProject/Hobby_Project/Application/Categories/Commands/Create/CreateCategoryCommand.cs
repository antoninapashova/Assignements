using Hobby_Project;
using MediatR;

namespace Application.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
