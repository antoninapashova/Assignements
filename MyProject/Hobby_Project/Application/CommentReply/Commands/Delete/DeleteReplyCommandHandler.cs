using Application.Logger;
using Application.Repositories;
using AutoMapper;
using HobbyProject.Application.CommentReply.Commands;
using HobbyProject.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HobbyProject.Application.CommentReply.Commands.Delete
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;

        public DeleteReplyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
        }

        public async Task<int> Handle(DeleteReplyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null)
                    throw new NullReferenceException("Delete reply command is null");

                await _unitOfWork.ReplyRepository.DeleteAsync(command.Id);
                await _unitOfWork.Save();

                return await Task.FromResult(command.Id);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
