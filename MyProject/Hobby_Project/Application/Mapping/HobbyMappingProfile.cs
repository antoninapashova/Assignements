using Application.Categories.Commands.Create;
using Application.Categories.Commands.Edit;
using Application.Comments.Commands.Create;
using Application.Comments.Commands.Edit;
using Application.Comments.Queries;
using Application.Hobby.Commands.Create;
using AutoMapper;
using Domain.Entity;
using Hobby_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class HobbyMappingProfile : Profile
    {
       public HobbyMappingProfile()
        {
            CreateMap<CreateCategoryCommand, HobbyCategory>();
            CreateMap<CreateCommentCommand, HobbyComment>();
            CreateMap<EditCategoryCommand, HobbyCategory>();
            CreateMap<EditCommentCommand, HobbyComment>();
            CreateMap<HobbyComment, CommentListVm>();
            CreateMap<CreateHobbyCommand, HobbyArticle>();
        }
    }
}
