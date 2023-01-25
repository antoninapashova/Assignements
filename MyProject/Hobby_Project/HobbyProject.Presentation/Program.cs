using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Repositories;
using Infrastructure.Repository;
using Infrastructure;
using Domain.Entity;
using System.Reflection;
using HobbyProject.Presentation;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using Microsoft.AspNetCore.Authentication;
using HobbyProject.Presentation.Middleware.UserMiddleware;
using HobbyProject.Presentation.Middleware.ExceptionMiddleware;
using FluentAssertions.Common;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
                      });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

builder.Services.AddMvc();
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
builder.Services.AddScoped<IUserConfiguration, UserConfiguration>();


builder.Services.AddMediatR(typeof(GetCategoriesListQuery).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(HobbyProject.Application.AssemblyMarketPresentatio));

builder.Services.AddDbContext<HobbyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddOptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<UserConfigurationMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseUserConfiguration();
app.Run();
