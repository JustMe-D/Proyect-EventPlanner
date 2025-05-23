using Microsoft.EntityFrameworkCore;
using Proyect_EventPlanner.Models;

namespace Proyect_EventPlanner.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Resource> Resources { get; set; }

    }
}
