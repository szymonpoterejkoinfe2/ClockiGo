using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.User.DeleteUserCommand
{
    public record DeleteUserCommand
        (
            Guid UserId,
            Guid SenderId
        ) : IRequest<ErrorOr<DeleteUserResult>>;
}
