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
using AutoMapper;
using Domain.Entity;
using Hobby_Project;
using HobbyProject.Application.Categories.Queries;
using HobbyProject.Application.Categories.Queries.GetSubCategoryFromCategory;
using HobbyProject.Application.Comments.Commands;
using HobbyProject.Application.Hobby.Commands;
using HobbyProject.Application.HobbyTags.Queries;
using HobbyProject.Application.User;
using HobbyProject.Application.User.Command.Create;
using HobbyProject.Domain.Entity;
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
            //User
            CreateMap<CreateUserCommand, UserEntity>();
            CreateMap<UserEntity, UserDto>();
            
            //HobbyArticle
            CreateMap<CreateHobbyCommand, HobbyEntity>();
            CreateMap<ArticleCommentDTO, HobbyEntity>();
            CreateMap<EditHobbyCommand, HobbyEntity>();
            CreateMap<HobbyEntity, HobbyDto>()
                //.ForMember("Username", x=>x.MapFrom(y=>y.Username))
                .ForMember("HobbySubCategory", x=>x.MapFrom(y=>y.HobbySubCategory.Name));

            //Category
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<EditCategoryCommand, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryWithSubCategoryVm>();

            //Subcategory
            CreateMap<CreateSubCategoryCommand, SubCategory>();
            CreateMap<SubCategory, HobbySubCategoryDto>();

            //Photo
            CreateMap<Photo, PhotoDTO>();
            CreateMap<PhotoDTO, Photo>();

            //Comment
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<EditCommentCommand, Comment>();
            CreateMap<Comment, CommentDto>();
            //.ForMember("Username", x=>x.MapFrom(y=>y.Username));
            CreateMap<Comment, HobbyCommentDTO>();
                //.ForMember("Username", x=>x.MapFrom(y=>y.Username));

            //Tag
            CreateMap<CreateTagCommand, Tag>();
            CreateMap<Tag, TagDto>();
            CreateMap<Tag, HobbyTagDto>();
            CreateMap<Tag, CreateHobbyTagDto>();
            CreateMap<CreateHobbyTagDto, Tag>();
       }
    }
}
