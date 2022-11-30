using Application.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbyTags.Queries
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagsListQuery, IEnumerable<TagListVm>>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagListQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        Task<IEnumerable<TagListVm>> IRequestHandler<GetTagsListQuery, IEnumerable<TagListVm>>.Handle(GetTagsListQuery request, CancellationToken cancellationToken)
        {
            var result = _tagRepository.GetAllTags().Select(tag => new TagListVm
            {
                 Name = tag.Name
            });

            return Task.FromResult(result);
        }
    }
}
