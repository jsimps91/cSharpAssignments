using Microsoft.EntityFrameworkCore;

namespace eCommerce.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options){}
        
        public DbSet<Product> Products {get;set;}
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Purchase> Purchases {get;set;}
        
    }
}