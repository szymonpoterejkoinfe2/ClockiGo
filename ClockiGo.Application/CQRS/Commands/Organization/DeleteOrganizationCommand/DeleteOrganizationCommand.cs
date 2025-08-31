using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.DeleteOrganizationCommand
{
    public record DeleteOrganizationCommand
        (
            Guid OrganizationId,
            Guid UserId
        ) : IRequest<ErrorOr<DeleteOrganizationResult>>;
}
