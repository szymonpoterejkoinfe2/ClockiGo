namespace ClockiGo.Contracts.Organization
{
    public record AddOrganizationResponse
        (
          Guid Id,
          string Name,
          string Email,
          string Phone
        );
}
