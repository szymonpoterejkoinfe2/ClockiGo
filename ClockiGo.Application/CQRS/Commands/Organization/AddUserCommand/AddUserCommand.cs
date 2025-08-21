using ClockiGo.Contracts.Organization;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.AddUserCommand
{
    public record AddUserCommand
        (
            Guid OrganizationId,
            Guid UserId
        ) : IRequest<ErrorOr<AddUserResult>>;
}
