using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Repositories;
//using Application.Cloudinary;
using Infrastructure.Repository;
using Infrastructure;
using Domain.Entity;
using System.Reflection;
using HobbyProject.Presentation;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using Microsoft.AspNetCore.Authentication;
using Application.Photos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IHobbyArticleRepository, HobbyRepository>();
builder.Services.AddScoped<IPhotoRepository, HobbyPhotoRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddMediatR(typeof(GetCategoriesListQuery).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(HobbyProject.Application.AssemblyMarketPresentatio));

builder.Services.AddDbContext<HobbyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddOptions();

builder.Services.Configure<CloudinarySettings>
    (builder.Configuration.GetSection("CloudinarySettings"));

//builder.Services.AddAuthentication("BasicAuthentication").
  //          AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
    //        ("BasicAuthentication", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
