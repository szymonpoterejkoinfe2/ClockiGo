using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Organization.AddOrganizationCommand
{
    public record AddOrganizationCommand
        (
            string Name,
            string Email,
            string Phone
        ) : IRequest<ErrorOr<AddOrganizationResult>>;
}
