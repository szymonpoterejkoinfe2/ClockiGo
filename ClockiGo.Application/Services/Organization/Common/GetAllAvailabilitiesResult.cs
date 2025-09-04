
namespace ClockiGo.Application.Services.Organization.Common
{
    public record GetAllAvailabilitiesResult
        (
            IReadOnlyList<Domain.Entities.Availability> Availabilities
        );
}
