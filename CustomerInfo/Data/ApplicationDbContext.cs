using CustomerInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasMany(c => c.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
