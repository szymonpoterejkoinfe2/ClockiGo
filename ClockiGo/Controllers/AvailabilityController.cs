using ClockiGo.Application.CQRS.Commands.Availability.AddAvailabilityCommand;
using ClockiGo.Application.CQRS.Commands.Availability.DeleteAvailabilityCommand;
using ClockiGo.Contracts.Availability;
using ClockiGo.Contracts.Organization;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            var command = new DeleteAvailabilityCommand(availabilityId);

            return Ok();
        }
    }
}
