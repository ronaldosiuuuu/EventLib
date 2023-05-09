using EventLib.model;
using Microsoft.EntityFrameworkCore;

namespace EventAPP.services
{
    public class EventDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbServer.GetConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           modelbuilder
                .Entity<Events>()
                .Property(e => e.EventSlags)
                .HasConversion(
                    v => v.ToString(),
                    v => (EventType)Enum.Parse(typeof(EventType), v));
        }
        public virtual DbSet<Events> EventSlags { get; set; } 
        public virtual DbSet<Events> Events { get; set; }
    }
}
