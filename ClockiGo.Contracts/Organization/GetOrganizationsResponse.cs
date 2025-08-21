namespace ClockiGo.Contracts.Organization
{
    public record GetOrganizationsResponse
        (
            IReadOnlyList<Domain.DTOs.OrganizationDTO> Organizations
        );
}
