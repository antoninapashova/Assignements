using Application.Categories.Commands.Create;
using Application.Categories.Commands.Delete;
using Application.Categories.Commands.Edit;
using Application.HobbyTags.Queries;
using Application.Users.Commands.Create;
using Application.Users.Commands.Delete;
using Application.Users.Commands.Edit;
using FluentValidation;
using HobbyProject.Application.Categories.Queries.GetCategoryById;
using HobbyProject.Application.Users.Queries.GetAllUsers;
using HobbyProject.Application.Users.Queries.GetUserById;
using HobbyProject.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IValidator<CreateUserCommand> _validator;
        public UserController(IMediator mediator, IValidator<CreateUserCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        { 
          var result = await _mediator.Send(new GetUserListQuery());
          return Ok(result);
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand command)
        {
           var result = await _mediator.Send(command);
           return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] EditUserCommand editUser)
        {
          
            editUser = new EditUserCommand { Id = id, Username = editUser.Username,
                FirstName = editUser.FirstName, LastName = editUser.LastName, 
                Age = editUser.Age, Email = editUser.Email,Password = editUser.Password };
             await _mediator.Send(editUser);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
          var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
            
        }

    }
}
