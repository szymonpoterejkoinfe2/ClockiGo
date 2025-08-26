using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.UpdateOrganizationCommand
{
    public record UpdateOrganizationCommand
        (
            Guid? OrganizationId,
            string Name,
            string Email,
            string Phone
        ) : IRequest<ErrorOr<UpdateOrganizationResult>>;
    
}
