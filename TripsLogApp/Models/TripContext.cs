using Microsoft.EntityFrameworkCore;

namespace TripsLogApp.Models
{
    // Database context for managing Trip entities
    public class TripContext : DbContext
    {
        // Constructor accepting options to configure the context
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }

        // DbSet representing the Trips table in the database
        public DbSet<Trip> Trips { get; set; }
    }
}
