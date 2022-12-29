using Application.Comments.Queries;
using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.Comments.Queries.GetAllComments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public GetCommentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }

        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.CommentRepository.GetByIdAsync(request.Id);
                CommentDto comments = _mapper.Map<CommentDto>(result);
                return await Task.FromResult(comments);

            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
