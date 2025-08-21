using ClockiGo.Domain.DTOs;

namespace ClockiGo.Contracts.Organization
{
    public record GetOrganizationResponse
        (
            OrganizationDTO Organization
        );
}
