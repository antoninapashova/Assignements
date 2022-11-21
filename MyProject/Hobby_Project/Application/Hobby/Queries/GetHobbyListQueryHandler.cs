using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Queries
{
     public class GetHobbyListQueryHandler : IRequestHandler<GetHobbyListQuery, IEnumerable<HobbyListVm>>
     {
       private readonly IHobbyRepository _repository;

        public GetHobbyListQueryHandler(IHobbyRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<HobbyListVm>> Handle(GetHobbyListQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAllHobbies().Select(hobby => new HobbyListVm
            {
                
                Title = hobby.Title,
                Description = hobby.Description,
                hobbySubCategory = hobby.HobbySubCategory,
                Comments = hobby.Comments.Select(com => new HobbyCommentDTO
                {
                   
                    CommentContent = com.CommentContent,
                    Title = com.Title,
                    User = com.User,


                }).ToList(),
                Tags = hobby.Tags.Select(tag=>new TagDTO
                {
                    
                    Name = tag.Name
                }).ToList()
            });

            return Task.FromResult(result);
        }
     }
}
