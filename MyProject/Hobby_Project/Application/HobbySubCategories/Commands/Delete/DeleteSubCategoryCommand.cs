using Domain.Interfaces;
using MediatR;

namespace Application.HobbySubCategories.Commands.Delete
{
    public class DeleteSubCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public IList<ISubscriber> Subscribers { get; set; } 
    }
}
