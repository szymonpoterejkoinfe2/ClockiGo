using ClockiGo.Application.Common.Interfaces.Persistance;
using ClockiGo.Domain.Entities;
using ClockiGo.Infrastructure.Presistance.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;


namespace ClockiGo.Infrastructure.Presistance.Repositories
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly ClockiGoContext _context;
        private readonly IMapper _mapper;

        public AvailabilityRepository(ClockiGoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(Availability availability)
        {
            var entity = _mapper.Map<AvailabilityEntity>(availability);
            await _context.Availabilities.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid AvailabilityId)
        {
            var availabilityToDelete = await _context.Availabilities.FirstOrDefaultAsync(a => a.Id == AvailabilityId);

            if (availabilityToDelete is null)
                return false;

            _context.Availabilities.Remove(availabilityToDelete);

            var succes = await _context.SaveChangesAsync();

            if (succes > 0)
                return true;
            else 
                return false;

        }

        public async Task<IReadOnlyList<Availability>> GetAvailabilitiesAsync()
        {
            var availabilityEntities = await _context.Availabilities.ToListAsync();

            var availabilities = _mapper.Map<IReadOnlyList<Availability>>(availabilityEntities);

            return availabilities;
        }

        public async Task<IReadOnlyList<Availability>> GetAvailabilitiesOfOrganizationAsync(Guid organizationId)
        {
            var availabilityEntities = await _context.Availabilities.Where(a => a.OrganizationId == organizationId).ToListAsync();

            var availabilities = _mapper.Map<IReadOnlyList<Availability>>(availabilityEntities);

            return availabilities;
        }

        public async Task<IReadOnlyList<Availability>> GetAvailabilitiesOfOrganizationInMonthOfYearAsync(Guid organizationId, DateOnly monthOfYear)
        {
            var startOfMonth = new DateTime(monthOfYear.Year, monthOfYear.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            endOfMonth = DateTime.SpecifyKind(endOfMonth, DateTimeKind.Utc);

            var availabilityEntities = await _context.Availabilities
                .Where(a => a.OrganizationId == organizationId &&
                           (a.AvailableFrom <= endOfMonth && a.AvailableTo >= startOfMonth))
                .ToListAsync();

            var availabilities = _mapper.Map<IReadOnlyList<Availability>>(availabilityEntities);
            return availabilities;
        }

        public async Task<IReadOnlyList<Availability>> GetAvailabilitiesOfUserAsync(Guid userId)
        {
            var availabilityEntities = await _context.Availabilities.Where(a => a.UserId == userId).ToListAsync();

            var availabilities = _mapper.Map<IReadOnlyList<Availability>>(availabilityEntities);

            return availabilities;
        }

        public async Task<IReadOnlyList<Availability>> GetAvailabilitiesOfUserInMonthOfYearAsync(Guid userId, DateOnly monthOfYear)
        {
            var startOfMonth = new DateTime(monthOfYear.Year, monthOfYear.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            endOfMonth = DateTime.SpecifyKind(endOfMonth, DateTimeKind.Utc);

            var availabilityEntities = await _context.Availabilities
                .Where(a => a.UserId == userId &&
                           (a.AvailableFrom <= endOfMonth && a.AvailableTo >= startOfMonth))
                .ToListAsync();

            var availabilities = _mapper.Map<IReadOnlyList<Availability>>(availabilityEntities);
            return availabilities;
        }

        public async Task<Availability?> GetAvailabilityByIdAsync(Guid id)
        {
            var entity = await _context.Availabilities.FirstOrDefaultAsync(a => a.Id == id);

            if (entity is null)
                return null;

            return _mapper.Map<Availability?>(entity);  
        }

        public async Task<bool> IsAnyAsync()
        {
           return await _context.Availabilities.AnyAsync();
        }

        public async Task<bool> UpdateAvailabilityAsync(Availability updatedAvailability)
        {
            var availabilityId = updatedAvailability.Id;
            var oldAvailability = await GetAvailabilityByIdAsync(availabilityId);

            if (oldAvailability is null) return false;

            oldAvailability = updatedAvailability;
            var entity = _mapper.Map<AvailabilityEntity>(oldAvailability);
            _context.Availabilities.Update(entity);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
