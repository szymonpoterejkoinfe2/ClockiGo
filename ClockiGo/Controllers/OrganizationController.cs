using ClockiGo.Application.CQRS.Commands.Organization.AddOrganizationCommand;
using ClockiGo.Application.CQRS.Commands.Organization.AddUserCommand;
using ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationsQuery;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Contracts.Organization;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClockiGo.Presentation.Controllers
{
    [Route("[controller]")]
    public class OrganizationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrganizationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        { 
            var query = new GetOrganizationsQuery();
            ErrorOr<GetOrganizationsResult> result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<GetOrganizationsResponse>(result)),
               errors => Problem(errors)
               );
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddOrganization([FromBody] AddOrganizationRequest request)
        {
            var command = _mapper.Map<AddOrganizationCommand>(request);

            ErrorOr<AddOrganizationResult> result = await _mediator.Send(command);


            return result.Match(
                result => Ok(_mapper.Map<AddOrganizationResponse>(result)),
                errors => Problem(errors)
                );
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUserToOrganization([FromBody] AddUserRequest request)
        {
            var command = _mapper.Map<AddUserCommand>(request);

            ErrorOr<AddUserResult> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<AddUserResponse>(result)),
                errors => Problem(errors)
            );
     

        }

    }
}
