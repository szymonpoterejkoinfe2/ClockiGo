using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.RemoveUserCommand
{
    public record RemoveUserCommand
        (
            Guid OrganizationId,
            Guid UserId
        ) : IRequest<ErrorOr<RemoveUserResult>>;
}
