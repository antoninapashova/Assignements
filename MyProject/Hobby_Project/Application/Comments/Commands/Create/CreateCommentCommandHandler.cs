using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var hobbyComment = _mapper.Map<Comment>(command);
                await _unitOfWork.CommentRepository.Add(hobbyComment);
                await _unitOfWork.Save();

                return hobbyComment.Id;
            } 
            catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
