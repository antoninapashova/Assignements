using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Repositories;
using Infrastructure.Repository;
using Infrastructure;
using System.Reflection;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Presentation.Middleware.UserMiddleware;
using HobbyProject.Presentation.Middleware.ExceptionMiddleware;
using FluentValidation.AspNetCore;
using HobbyProject.Application.Repositories;
using HobbyProject.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HobbyProject.Application.Helpers;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .WithOrigins("http://localhost:4200")
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod(); 
                      });
});

builder.Services.AddControllers().AddFluentValidation(options =>
                {
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

builder.Services.AddMvc();
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
builder.Services.AddScoped<IUserConfiguration, UserConfiguration>();
builder.Services.AddScoped<ITokenManager, TokenManager>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddMediatR(typeof(GetCategoriesListQuery).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(HobbyProject.Application.AssemblyMarketPresentatio));

builder.Services.AddDbContext<HobbyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret.......")),
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddOptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseMiddleware<UserConfigurationMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseUserConfiguration();
app.Run();
