using ClockiGo.Application.CQRS.Commands.Availability.AddAvailabilityCommand;
using ClockiGo.Application.CQRS.Commands.Availability.DeleteAvailabilityCommand;
using ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesOfUserQuery;
using ClockiGo.Application.CQRS.Queries.Availability.GetAllAvailabilitiesQuery;
using ClockiGo.Contracts.Availability;
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
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return BadRequest();

            var query = new GetAllAvailabilitiesQuery(userId);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<GetAllAvailabilitiesResponse>(result)),
                errors => Problem(errors)
                );

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllAvailabilitiesOfUser(Guid userId)
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid senderId))
                return BadRequest();

            var query = new GetAllAvailabilitiesOfUserQuery(userId, senderId);
            var result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<GetAllAvailabilitiesOfUserResponse>(result)),
                errors => Problem(errors)
                );
        }

        [HttpGet("{userId}/inTime")]
        public async Task<IActionResult> GetAllAvailabilitiesOfUserInMonthOfYear(Guid userId,[FromQuery] DateTime monthYear)
        {

            return Ok();
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
