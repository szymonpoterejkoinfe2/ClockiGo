namespace ClockiGo.Application.Services.Organization.Common
{
    public record GetOrganizationsResult
    (
        IReadOnlyList<Domain.Entities.Organization> Organizations
    );
}
