using ClockiGo.Application.CQRS.Commands.Availability.AddAvailabilityCommand;
using ClockiGo.Application.CQRS.Commands.Availability.DeleteAvailabilityCommand;
using ClockiGo.Contracts.Availability;
using ClockiGo.Contracts.Organization;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClockiGo.Presentation.Controllers
{
    [Route("[controller]")]
    public class AvailabilityController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AvailabilityController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAvailabilities()
        {
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllAvailabilitiesOfUser(Guid userId)
        {
            return Ok(0);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddAvailability([FromBody] AddAvailabilityRequest request)
        {
            var command = _mapper.Map<AddAvailabilityCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<AddAvailabilityResponse>(result)),
                errors => Problem(errors)
                );
        }

        [HttpDelete("{availabilityId}")]
        public async Task<IActionResult> DeleteAvailability(Guid availabilityId)
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return BadRequest();

            var command = new DeleteAvailabilityCommand(availabilityId,userId);
            var result = await _mediator.Send(command);

            return result.Match(
               result => Ok(_mapper.Map<DeleteAvailabilityResponse>(result)),
               errors => Problem(errors)
               );
        }
    }
}
