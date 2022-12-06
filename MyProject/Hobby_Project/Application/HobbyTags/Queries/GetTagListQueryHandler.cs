using Application.Categories.Queries;
using Application.Repositories;
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

        public async Task<IEnumerable<TagListVm>> Handle(GetTagsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _tagRepository.GetAllEntitiesAsync();
            var tags = result.Select(tag => new TagListVm
            {
                Name = tag.Name
            });

            return await Task.FromResult(tags.ToList());
        }
    }
}
