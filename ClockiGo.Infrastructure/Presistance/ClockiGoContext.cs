using ClockiGo.Infrastructure.Presistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClockiGo.Infrastructure.Presistance
{
    public class ClockiGoContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<AvailabilityEntity> Availabilities { get; set; }  

        public ClockiGoContext(DbContextOptions<ClockiGoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
