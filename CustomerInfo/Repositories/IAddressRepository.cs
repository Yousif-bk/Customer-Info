using CustomerInfo.Dtos;
using CustomerInfo.Models;

namespace CustomerInfo.Repositories
{
    public interface IAddressRepository
    {
        Task CreateAddressAsync(Address address);
        Task DeleteAddress(Address address);
        Task<Address> GetAddressAsync(Guid id);
        Task<IEnumerable<Address>> GetAllAddressesAsync();
    }
}
