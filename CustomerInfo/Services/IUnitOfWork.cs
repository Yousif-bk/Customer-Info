using CustomerInfo.Repositories;

namespace CustomerInfo.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository  { get; }
        ICustomerRepository CustomerRepository { get; }
        Task<int> SaveAsync();
    }
}
