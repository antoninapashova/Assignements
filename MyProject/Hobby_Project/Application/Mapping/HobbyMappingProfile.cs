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
using HobbyProject.Application.Categories.Queries;
using HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory;
using HobbyProject.Application.Comments.Commands;
using HobbyProject.Application.Hobby.Commands;
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
            
            //HobbyArticle
            CreateMap<CreateHobbyCommand, HobbyArticle>();
            CreateMap<ArticleCommentDTO, HobbyArticle>();
            CreateMap<EditHobbyCommand, HobbyArticle>();
            CreateMap<HobbyArticle, HobbyDto>()
                .ForMember("Username", x=>x.MapFrom(y=>y.User.Username))
                .ForMember("HobbySubCategory", x=>x.MapFrom(y=>y.HobbySubCategory.Name));

            //Category
            CreateMap<CreateCategoryCommand, HobbyCategory>();
            CreateMap<EditCategoryCommand, HobbyCategory>();
            CreateMap<HobbyCategory, CategoryDto>();
            CreateMap<HobbyCategory, CategoryWithSubCategoryVm>();

            //Subcategory
            CreateMap<CreateSubCategoryCommand, HobbySubCategory>();
            CreateMap<HobbySubCategory, HobbySubCategoryDto>();

            //Photo
            CreateMap<PhotoDTO, HobbyPhoto>();

            //Comment
            CreateMap<CreateCommentCommand, HobbyComment>();
            CreateMap<EditCommentCommand, HobbyComment>();
            CreateMap<HobbyComment, CommentDto>()
                .ForMember("Username", x=>x.MapFrom(y=>y.User.Username));
            CreateMap<HobbyComment, HobbyCommentDTO>()
                .ForMember("Username", x=>x.MapFrom(y=>y.User.Username));

            //User
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDto>();
            CreateMap<EditUserCommand, User>();

            //Tag
            CreateMap<CreateTagCommand, Tag>();
            CreateMap<Tag, TagDto>();
            CreateMap<Tag, HobbyTagDto>();
            CreateMap<Tag, CreateHobbyTagDto>();
            CreateMap<CreateHobbyTagDto, Tag>();
       }
    }
}
