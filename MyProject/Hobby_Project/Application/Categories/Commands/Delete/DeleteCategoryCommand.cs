using MediatR;

namespace Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
