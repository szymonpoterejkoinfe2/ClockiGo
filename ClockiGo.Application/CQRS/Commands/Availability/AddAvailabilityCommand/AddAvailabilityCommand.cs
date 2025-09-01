using ClockiGo.Application.Services.Availability.Common;
using ErrorOr;
using MediatR;

namespace ClockiGo.Application.CQRS.Commands.Availability.AddAvailabilityCommand
{
    public record AddAvailabilityCommand(

            byte AvailabilityType,
            DateTime AvailabilityFrom,
            DateTime AvailabilityTo,
            Guid UserId,
            Guid OrganizationId

        ) : IRequest<ErrorOr<AddAvailabilityResult>>;
}
