using ClockiGo.Domain.Entities;

namespace ClockiGo.Application.Common.Interfaces.Persistance
{
    public interface IAvailabilityRepository
    {
        Task<bool> IsAnyAsync();
        Task<IReadOnlyList<Availability>> GetAvailabilitiesAsync();
        Task<Availability?> GetAvailabilityByIdAsync(Guid id);
        Task<IReadOnlyList<Availability>> GetAvailabilitiesOfUserAsync(Guid userId);
        Task<IReadOnlyList<Availability>> GetAvailabilitiesOfUserInMonthOfYearAsync(Guid userId, DateOnly monthOfYear);
        Task<IReadOnlyList<Availability>> GetAvailabilitiesOfOrganizationAsync(Guid organizationId);
        Task<IReadOnlyList<Availability>> GetAvailabilitiesOfOrganizationInMonthOfYearAsync(Guid organizationId, DateOnly monthOfYear);
        Task<bool> UpdateAvailabilityAsync(Availability updatedAvailability);
        Task AddAsync(Availability availability);
        Task<bool> DeleteAsync(Guid AvailabilityId);
    }
}
