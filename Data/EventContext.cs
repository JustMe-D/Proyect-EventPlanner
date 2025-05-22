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
    }
}
