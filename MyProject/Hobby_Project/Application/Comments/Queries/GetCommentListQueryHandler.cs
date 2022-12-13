
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries.GetAllCategories
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentsListQuery, IEnumerable<CommentListVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetCommentListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentListVm>> Handle(GetCommentsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.CommentRepository.GetAllEntitiesAsync();
            List<CommentListVm> comments = _mapper.Map<List<CommentListVm>>(result.ToList());

            return await Task.FromResult(comments);
        }
    }
}
