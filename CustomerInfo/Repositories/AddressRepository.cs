using CustomerInfo.Data;
using CustomerInfo.Dtos;
using CustomerInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public  async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            IEnumerable<Address> address = await _context.Address.ToListAsync();
            return address;
        }
        public async Task CreateAddressAsync(Address address)
        {
            await _context.Address.AddAsync(address);
        }

        public async Task DeleteAddress(Address address)
        {
              _context.Address.Remove(address);
        }

        public async Task<Address> GetAddressAsync(Guid id)
        {
            Address address = await _context.Address.SingleOrDefaultAsync(c => c.Id == id);
            return address;
        }
    }
}
