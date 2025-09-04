using ClockiGo.Domain.DTOs;

namespace ClockiGo.Application.Services.Organization.Common
{
    public record GetAllAvailabilitiesOfUserResult
        (
            IReadOnlyList<Domain.Entities.Availability> Availabilities
        );

}
