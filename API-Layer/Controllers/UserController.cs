using MediatR;
using ApplicationLayer.Users.Querries;
using ApplicationLayer.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ApplicationLayer.Users.Commands.UpdateUser;
using ApplicationLayer.Users.Commands.DeleteUser;
using ApplicationLayer.DTOs;
using ApplicationLayer.Responses;
using DomainLayer.Models;

namespace API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<OperationResult<List<UserDTO>>>> GetUsers()
        {
            var result = await _mediator.Send(new GettAllUsersQuery());

            if (result == null || !result.Any())
                return NotFound(OperationResult<List<UserDTO>>.Fail("Inga användare hittades."));

            return Ok(OperationResult<List<User>>.Ok(result));
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<OperationResult<int>>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == null) 
                return BadRequest(OperationResult<int>.Fail("Användaren kunde inte skapas."));

            return Ok(OperationResult<string>.Ok(result, "Användare skapades."));
        }



        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> UpdateUser(int id, [FromBody] UserDTO dto)
        {
            var command = new UpdateUserCommand(new DomainLayer.Models.User
            {
                Id = id,
                Name = dto.Name,
                Email = dto.Email
            });

            if (id != command.User.Id)
                return BadRequest(OperationResult<bool>.Fail("ID i URL matchar inte användarens ID."));

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound(OperationResult<bool>.Fail("Användaren kunde inte uppdateras."));

            return Ok(OperationResult<bool>.Ok(true, "Användare uppdaterades."));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> DeleteUser(int id, [FromBody] DeleteUserCommand command)
        {
            if (id != command.Id)
                return BadRequest(OperationResult<bool>.Fail("ID i URL matchar inte kommando-ID."));

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound(OperationResult<bool>.Fail("Användaren kunde inte hittas eller tas bort."));

            return Ok(OperationResult<bool>.Ok(true, "Användare togs bort."));
        }

    }
}
