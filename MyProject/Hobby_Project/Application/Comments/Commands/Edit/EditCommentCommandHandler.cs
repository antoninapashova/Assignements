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

namespace Application.Comments.Commands.Edit
{
    public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public EditCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(EditCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null)  throw new NullReferenceException("Edit comment command is null");

                Comment hobbyComment = _mapper.Map<Comment>(command);
                await _unitOfWork.CommentRepository.Update(hobbyComment);
                await _unitOfWork.Save();
                return await Task.FromResult(command.Id);

            }catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
