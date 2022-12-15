using Application.Logger;
using Application.Notifications;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HobbySubCategories.Commands.Create
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, HobbySubCategory>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly HobbyPublisher _hobbyPublisher;
        private ILog _log;
        private IMapper _mapper;

        public CreateSubCategoryCommandHandler(IUnitOfWork unitOfWork
            //, HobbyPublisher hobbyPublisher
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           // _hobbyPublisher = hobbyPublisher;
            _log = SingletonLogger.Instance;
            _mapper= mapper;
        }

        public async Task<Hobby_Project.HobbySubCategory> Handle(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) throw new NullReferenceException("Create sub category command is null!");
                Hobby_Project.HobbySubCategory hobbySubCategory = _mapper.Map<Hobby_Project.HobbySubCategory>(command);
                await _unitOfWork.SubCategoryRepository.Add(hobbySubCategory);
                await _unitOfWork.Save();
                //_hobbyPublisher.Publish(hobbySubCategory);
                return await Task.FromResult(hobbySubCategory);
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
                return await Task.FromResult<Hobby_Project.HobbySubCategory>(null);
            }
        }
    }
}
