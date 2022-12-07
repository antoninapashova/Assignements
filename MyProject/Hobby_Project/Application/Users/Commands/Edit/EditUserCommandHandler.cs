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

namespace Application.Users.Commands.Edit
{
    internal class EditUserCommandHandler : IRequestHandler<EditUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public EditUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(command);
            await _unitOfWork.UserRepository.UpdateAsync(command.Id, user);
            await _unitOfWork.Save();
            return await Task.FromResult(command.Id);
        }
        
    }
}
