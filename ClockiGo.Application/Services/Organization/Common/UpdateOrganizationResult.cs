using ClockiGo.Domain.Entities;

namespace ClockiGo.Application.Services.Organization.Common
{
    public record UpdateOrganizationResult
        (
            Domain.Entities.Organization Organization
        );
}
