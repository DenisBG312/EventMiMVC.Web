
using EventMiWorkshopMVC.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMiWorkshopMVC.Data
{
    public class EventMiDbContext : DbContext
    {
        public EventMiDbContext()
        {

        }

        public EventMiDbContext(DbContextOptions<EventMiDbContext> options)
            : base (options)
        {

        }

        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);
        }
    }
}
