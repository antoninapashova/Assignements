using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using HobbyProject.Application.Categories.Queries.GetAllCategories;
using HobbyProject.Presentation.Middleware.ExceptionMiddleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HobbyProject.Application.Helpers;
using HobbyProject.Infrastructure.Data;
using HobbyProject.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

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

builder.Services.AddDbConfiguration(connectionString);
builder.Services.AddRepositoryConfigurations();

builder.Services.AddTransient<ITokenManager, TokenManager>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddMediatR(typeof(GetCategoriesListQuery).GetTypeInfo().Assembly);
builder.Services.AddAutoMapper(typeof(HobbyProject.Application.AssemblyMarketPresentatio));
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

builder.Services.AddOptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DbInitializer.Run(app.Services);

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();
