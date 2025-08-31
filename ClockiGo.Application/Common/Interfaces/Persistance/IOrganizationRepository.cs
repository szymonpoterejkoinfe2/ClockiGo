using ClockiGo.Domain.Entities;

namespace ClockiGo.Application.Common.Interfaces.Persistance
{
    public interface IOrganizationRepository
    {
        Task<bool> IsAnyAsync();
        Task<IReadOnlyList<Organization>> GetOrganizationsAsync();
        Task<Organization?> GetOrganizationByIdAsync(Guid id);
        Task<Organization?> GetOrganizationByEmailAsync(string email);
        Task<bool> UpdateOrganizationAsync(Organization updatedOrganization);
        Task AddAsync(Organization organization);
        Task<bool> DeleteAsync(Guid organizationId);
        Task<bool> AddUser(Guid organizationId, Guid userId);
        Task<bool> RemoveUser(Guid organizationId, Guid userId);
    }
}
