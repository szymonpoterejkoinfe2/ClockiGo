using ClockiGo.Application.Services.Organization.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Availability.DeleteAvailabilityCommand
{
    public record DeleteAvailabilityCommand
        (
            Guid AvailabilityId,
            Guid UserId
        ) : IRequest<ErrorOr<DeleteAvailabilityResult>>;
}
