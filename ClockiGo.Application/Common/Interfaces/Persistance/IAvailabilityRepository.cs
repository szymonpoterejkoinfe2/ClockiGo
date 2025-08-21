using ClockiGo.Domain.Entities;

namespace ClockiGo.Application.Common.Interfaces.Persistance
{
    public interface IAvailabilityRepository
    {
        Task<bool> IsAnyAsync();
        Task<IReadOnlyList<Availability>> GetAvailabilitiesAsync();
        Task<Availability?> GetAvailabilityByIdAsync(Guid id);
        Task<IReadOnlyList<Availability>> GetAvailabilitiesOfUserAsync(Guid userId);
        Task<bool> UpdateAvailabilityAsync(Availability updatedAvailability);
        Task AddAsync(Availability availability);
        Task<bool> DeleteAsync(Guid AvailabilityId);
    }
}
