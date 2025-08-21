using ClockiGo.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        string Password
        ) : IRequest<ErrorOr<AuthenticationResult>>;
}
