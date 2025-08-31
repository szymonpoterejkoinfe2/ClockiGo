using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Domain.Entities;
using ClockiGo.Infrastructure.Presistance.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ClockiGo.Infrastructure.Presistance.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ClockiGoContext _clockiGoContext;
        private readonly IMapper _mapper;

        public OrganizationRepository(ClockiGoContext clockiGoContext, IMapper mapper)
        {
            _clockiGoContext = clockiGoContext;
            _mapper = mapper;
        }

        public async Task<bool> IsAnyAsync()
        {
            return await _clockiGoContext.Organizations.AnyAsync();
        }

        public async Task<IReadOnlyList<Organization>> GetOrganizationsAsync()
        {
            var organizationEntities = await _clockiGoContext.Organizations.Include(o => o.Users).ToListAsync();
            var organizations = _mapper.Map<IReadOnlyList<Organization>>(organizationEntities);

            return organizations;
        }

        public async Task<Organization?> GetOrganizationByIdAsync(Guid id)
        { 
            var organizationEntity = await _clockiGoContext.Organizations.Include(o => o.Users).FirstOrDefaultAsync(o => o.Id == id);
            if (organizationEntity is null)
                return null; 
            
            var organization = _mapper.Map<Organization>(organizationEntity);   
            return organization;
        }

        public async Task<Organization?> GetOrganizationByEmailAsync(string email)
        {
            var organizationEntity = await _clockiGoContext.Organizations.FirstOrDefaultAsync(o => o.Email == email);
            if (organizationEntity is null)
                return null;

            var organization = _mapper.Map<Organization>(organizationEntity);
            return organization;
        }

        public async Task<bool> UpdateOrganizationAsync(Organization updatedOrganization)
        {
            var existingEntity = await _clockiGoContext.Organizations.FirstOrDefaultAsync(o => o.Id == updatedOrganization.Id);
            if (existingEntity is null) return false;

            _mapper.Map(updatedOrganization, existingEntity);
           
            await Save();

            return true;
        }


        public async Task AddAsync(Organization organization)
        { 
            var organizationEntity = _mapper.Map<OrganizationEntity>(organization);     
            await _clockiGoContext.Organizations.AddAsync(organizationEntity);

            await Save();
        }

        public async Task<bool> DeleteAsync(Guid organizationId)
        {
            var organizationEntity = await _clockiGoContext.Organizations.FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organizationEntity is null)
                return false;

            _clockiGoContext.Organizations.Remove(organizationEntity);
            await Save();

            return true;
        }


        private async Task Save()
        {
           await _clockiGoContext.SaveChangesAsync();
        }

        public async Task<bool> AddUser(Guid organizationId, Guid userId)
        {
            var organizationEntity = await _clockiGoContext.Organizations
                .Include(o => o.Users)
                .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organizationEntity is null) return false;

            if (organizationEntity.Users is null)
            {
                organizationEntity.Users = new List<UserEntity>();
            }

            var userEntity = await _clockiGoContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (userEntity is null) return false;

            if (organizationEntity.Users.Any(u => u.Id == userId))
                return true;

            organizationEntity.Users.Add(userEntity);

            await Save();
            return true;
        }

        public async Task<bool> RemoveUser(Guid organizationId, Guid userId)
        {
            var organizationEntity = await _clockiGoContext.Organizations
                  .Include(o => o.Users)
                  .FirstOrDefaultAsync(o => o.Id == organizationId);

            if (organizationEntity is null || organizationEntity.Users is null || !organizationEntity.Users.Any(u => u.Id == userId)) return false;

            var userToRemove = organizationEntity.Users.FirstOrDefault(u => u.Id == userId);
            if (userToRemove is null) return false;

            organizationEntity.Users.Remove(userToRemove);
            await Save(); 
            
            return true;
        }
    }
}
