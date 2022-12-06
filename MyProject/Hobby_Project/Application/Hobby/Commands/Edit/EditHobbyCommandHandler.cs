using Application.Logger;
using Application.Repositories;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hobby.Commands.Edit
{
    internal class EditHobbyCommandHandler 
        //: IRequestHandler<EditHobbyCommand, int>
    {
        private readonly IHobbyArticleRepository _hobbyRepository;
        private ILog _log;

        public EditHobbyCommandHandler(IHobbyArticleRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
            _log = SingletonLogger.Instance;
        }
        /*
        public async Task<int> Handle(EditHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
               if (command == null) throw new NullReferenceException("Edit hobby command is null");
                HobbyArticle hobbyArticle = new HobbyArticle(command.Title, command.Description);
              await _hobbyRepository.UpdateAsync(command.Id,hobbyArticle);
               return await Task.FromResult(command.Id);
            }catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult(0);
            }
            
        }
        */
    }
}
