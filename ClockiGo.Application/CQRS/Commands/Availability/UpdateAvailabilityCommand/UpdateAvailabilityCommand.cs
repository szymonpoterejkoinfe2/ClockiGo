using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Availability.UpdateAvailabilityCommand
{
    public record UpdateAvailabilityCommand
        (
           Guid SenderId,
           Guid Id,
           int AvailabilityType,
           DateTime AvailableFrom,
           DateTime AvailableTo
        ) : IRequest<ErrorOr<UpdateAvailabilityResult>>;
}
