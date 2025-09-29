using ClockiGo.Application.CQRS.Commands.Organization.AddOrganizationCommand;
using ClockiGo.Application.CQRS.Commands.Organization.AddUserCommand;
using ClockiGo.Application.CQRS.Commands.Organization.DeleteOrganizationCommand;
using ClockiGo.Application.CQRS.Commands.Organization.RemoveUserCommand;
using ClockiGo.Application.CQRS.Commands.Organization.UpdateOrganizationCommand;
using ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationQuery;
using ClockiGo.Application.CQRS.Queries.Organization.GetOrganizationsQuery;
using ClockiGo.Application.Services.Organization.Common;
using ClockiGo.Contracts.Organization;
using ClockiGo.Contracts.User;
using ClockiGo.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("{organizationId}")]
        public async Task<IActionResult> GetOrganizationById(Guid organizationId)
        {
            var query = new GetOrganizationQuery(OrganizationId: organizationId);
            ErrorOr<GetOrganizationResult> result = await _mediator.Send(query);


            return result.Match(
               result => Ok(_mapper.Map<GetOrganizationResponse>(result)),
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

        [HttpPost("{organizationId}/AddUser")]
        public async Task<IActionResult> AddUserToOrganization(Guid organizationId, [FromBody] AddUserRequest request)
        {
            var command = new AddUserCommand(OrganizationId: organizationId, UserId: request.UserId);

            ErrorOr<AddUserResult> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<AddUserResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{organizationId}/RemoveUser{userId}")]
        public async Task<IActionResult> RemoveUserFromOrganization(Guid organizationId, Guid userId)
        {
            var command = new RemoveUserCommand(organizationId, userId);

            ErrorOr<RemoveUserResult> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<RemoveUserResponse>(result)),
                errors => Problem(errors)
            );
        }


        [HttpDelete("{organizationId}")]
        public async Task<IActionResult> DeleteOrganization(Guid organizationId)
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return BadRequest();

            var command = new DeleteOrganizationCommand(organizationId,userId);

            ErrorOr<DeleteOrganizationResult> result = await _mediator.Send(command);


            return result.Match(
                result => Ok(_mapper.Map<DeleteOrganizationResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPut("{organizationId}")]
        public async Task<IActionResult> UpdateOrganization(Guid organizationId,[FromBody] UpdateOrganizationRequest request)
        {
            if (organizationId != request.OrganizationId)
                return BadRequest(Errors.Organization.OrganizationIdMismatch);

            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                return BadRequest(Errors.User.UserNotFound);


            var command = new UpdateOrganizationCommand(UserId: userId,
                OrganizationId: request.OrganizationId,
                Name: request.Name,
                Email: request.Email,
                Phone: request.Phone);
            

            ErrorOr<UpdateOrganizationResult> result = await _mediator.Send(command);

            var test = result.Value;

            return result.Match(
                result => Ok(_mapper.Map<UpdateOrganizationResponse>(result)),
                errors => Problem(errors)
            );
        }

    }
}
