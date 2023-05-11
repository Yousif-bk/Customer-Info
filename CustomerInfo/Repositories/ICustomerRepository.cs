using CustomerInfo.Dtos;
using CustomerInfo.Models;

namespace CustomerInfo.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerAsync(Guid customerId);
        Task CreateCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetCustomersByCityAsync(string cityName);
    }
}
