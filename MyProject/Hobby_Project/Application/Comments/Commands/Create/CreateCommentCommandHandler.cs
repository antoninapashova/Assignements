using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Commands.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILog _log;
        private IMapper _mapper;

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
                if (command == null) throw new NullReferenceException("Create comment command is null");
                HobbyComment hobbyComment = _mapper.Map<HobbyComment>(command);
                await _unitOfWork.CommentRepository.Add(hobbyComment);
                await _unitOfWork.Save();
                return await Task.FromResult(hobbyComment.Id);
            } catch(Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
        }
    }
}
