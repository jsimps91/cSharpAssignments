using Microsoft.EntityFrameworkCore;
namespace weddingPlanner.Models
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions<PlannerContext> options) : base(options) { }
        public DbSet<Wedding> Weddings {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<RSVP> RSVPS {get;set;}
    }
}