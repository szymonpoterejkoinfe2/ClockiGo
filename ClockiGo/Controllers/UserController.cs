using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Application.CQRS.Commands.User.DeleteUserCommand;
using ClockiGo.Contracts.Organization;
using ClockiGo.Contracts.User;
using ClockiGo.Domain.DTOs;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClockiGo.Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid senderId))
                return BadRequest();

            var command = new DeleteUserCommand(userId, senderId);
            var result = await _mediator.Send(command);

            return result.Match(
               result => Ok(_mapper.Map<DeleteUserResponse>(result)),
               errors => Problem(errors)
               );
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserDTO userToDelete)
        {
            return Ok(Array.Empty<string>());
        }

    }
}
