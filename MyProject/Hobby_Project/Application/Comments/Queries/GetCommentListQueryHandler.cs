using Application.Categories.Queries;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<CommentListVm>>
    {
        private readonly ICommentRepository _commentRepository;
        private IMapper _mapper;
        public GetCommentListQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentListVm>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _commentRepository.GetAllEntitiesAsync();
            List<CommentListVm> commentListVms = _mapper.Map<List<CommentListVm>>(result);

            return await Task.FromResult(commentListVms);
        }
    }
}
