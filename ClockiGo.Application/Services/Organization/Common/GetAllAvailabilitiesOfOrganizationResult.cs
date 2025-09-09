namespace ClockiGo.Application.Services.Organization.Common
{
    public record GetAllAvailabilitiesOfOrganizationResult
    (
        IReadOnlyList<Domain.Entities.Availability> Availabilities
    );
}
