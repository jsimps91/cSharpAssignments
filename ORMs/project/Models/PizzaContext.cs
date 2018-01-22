using Microsoft.EntityFrameworkCore;
 
namespace project.Models
{
    public class PizzaContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}