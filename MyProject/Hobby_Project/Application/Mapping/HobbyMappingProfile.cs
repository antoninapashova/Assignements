using Application.Categories.Commands.Create;
using Application.Categories.Commands.Edit;
using Application.Categories.Queries;
using Application.Comments.Commands.Create;
using Application.Comments.Commands.Edit;
using Application.Comments.Queries;
using Application.Hobby.Commands.Create;
using Application.Hobby.Commands.Edit;
using Application.Hobby.Queries;
using Application.HobbySubCategories.Commands.Create;
using Application.HobbySubCategories.Queries;
using Application.HobbyTags.Commands.Create;
using Application.HobbyTags.Queries;
using Application.Users.Commands.Edit;
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
            //Create
            CreateMap<CreateCategoryCommand, HobbyCategory>();
            CreateMap<CreateCommentCommand, HobbyComment>();
            CreateMap<CreateHobbyCommand, HobbyArticle>();
            CreateMap<CreateSubCategoryCommand, HobbySubCategory>();
            CreateMap<CreateTagCommand, Tag>();
            //Edit
            CreateMap<EditCategoryCommand, HobbyCategory>();
            CreateMap<EditCommentCommand, HobbyComment>();
            CreateMap<EditHobbyCommand, HobbyArticle>();
            CreateMap<EditUserCommand, User>();
            //Get
            CreateMap<HobbyComment, CommentListVm>();
            CreateMap<HobbyCategory, CategoryListVm>();
            CreateMap<HobbyArticle, HobbyListVm>();
            CreateMap<HobbySubCategory, HobbySubCategoryListVm>();
            CreateMap<Tag, TagListVm>();
        }
    }
}
