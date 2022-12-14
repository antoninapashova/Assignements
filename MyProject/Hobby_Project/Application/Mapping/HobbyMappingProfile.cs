using Application.Categories.Commands.Create;
using Application.Categories.Commands.Edit;
using Application.Comments.Commands.Create;
using Application.Comments.Commands.Edit;
using Application.Comments.Queries;
using Application.Hobby.Commands.Create;
using Application.Hobby.Commands.Edit;
using Application.Hobby.Queries;
using Application.HobbySubCategories.Commands.Create;
using Application.HobbyTags.Commands.Create;
using Application.Users.Commands.Create;
using Application.Users.Commands.Edit;
using Application.Users.Queries;
using AutoMapper;
using Domain.Entity;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory;
using HobbyProject.Application.HobbySubCategories.Queries;
using HobbyProject.Application.HobbyTags.Queries;
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
            CreateMap<CreateUserCommand, User>();
            //Edit
            CreateMap<EditCategoryCommand, HobbyCategory>();
            CreateMap<EditCommentCommand, HobbyComment>();
            CreateMap<EditHobbyCommand, HobbyArticle>();
            CreateMap<EditUserCommand, User>();
            //Get
            CreateMap<HobbyComment, CommentListVm>();
            CreateMap<HobbySubCategory, HobbySubCategoryDTO>();
            CreateMap<HobbyArticle, HobbyListVm>();
            CreateMap<HobbySubCategory, HobbySubCategoryVm>();
            CreateMap<HobbyCategory, CategoryVm>();
            CreateMap<HobbyCategory, CategoryWithSubCategoryVm>();
            CreateMap<Tag, TagVm>();
            CreateMap<User, UserVm>();
       }
    }
}
