using ClockiGo.Domain.Entities;

namespace ClockiGo.Application.Services.Authentication.Common
{
    public record AuthenticationResult
     (
        User User,
        string Token
    );
}
