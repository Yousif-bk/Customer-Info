using CustomerInfo.Data;
using CustomerInfo.Dtos;
using CustomerInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
             await _context.Customers.AddAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByCityAsync(string cityName)
        {
            return await _context.Customers
                    .Where(c => c.Addresses.Any(a => a.City == cityName))
                    .ToListAsync();
        }
    }
}
