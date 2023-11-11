using Application.Categories.Commands.Create;
using Application.Comments.Commands.Create;
using Application.Comments.Commands.Edit;
using Application.Hobby.Commands.Create;
using Application.Hobby.Commands.Edit;
using Application.HobbySubCategories.Commands.Create;
using Application.HobbyTags.Commands.Create;
using AutoMapper;
using Domain.Entity;
using Hobby_Project;
using HobbyProject.Application.Categories.Dto;
using HobbyProject.Application.CommentReply;
using HobbyProject.Application.CommentReply.Commands;
using HobbyProject.Application.Comments.Commands;
using HobbyProject.Application.Comments.Dto;
using HobbyProject.Application.Hobby.Dto;
using HobbyProject.Application.HobbyTags.Queries;
using HobbyProject.Application.User.Command.Create;
using HobbyProject.Application.User.Dto;
using HobbyProject.Domain.Entity;

namespace Application.Mapping
{
    public class HobbyMappingProfile : Profile
    {
       public HobbyMappingProfile()
       {
            CreateMap<CreateUserCommand, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<CreateHobbyCommand, HobbyEntity>();
            CreateMap<ArticleCommentDTO, HobbyEntity>();
            CreateMap<UpdateHobbyCommand, HobbyEntity>();
            CreateMap<HobbyEntity, HobbyDto>()
                .ForMember("Username", x => x.MapFrom(y => y.User.Username))
                .ForMember("HobbySubCategory", x=>x.MapFrom(y=>y.HobbySubCategory.Name));

            CreateMap<CreateCategoryCommand, Category>();
            
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryNameDto>();

            
            CreateMap<CreateSubCategoryCommand, SubCategory>();
            CreateMap<SubCategory, HobbySubCategoryDto>();

            CreateMap<Photo, PhotoDTO>();
            CreateMap<PhotoDTO, Photo>();

            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<EditCommentCommand, Comment>();
            CreateMap<Comment, CommentDto>()
            .ForMember("Username", x=>x.MapFrom(y=>y.User.Username));

            CreateMap<CreateReplyCommand, Reply>();
            CreateMap<Reply, ReplyDto>()
                .ForMember("Username", x => x.MapFrom(y => y.User.Username));

            CreateMap<CreateHobbyTagDto, Tag>();
            CreateMap<CreateTagCommand, Tag>();
            CreateMap<Tag, TagDto>();
            CreateMap<Tag, HobbyTagDto>();
            CreateMap<Tag, CreateHobbyTagDto>();
       }
    }
}
