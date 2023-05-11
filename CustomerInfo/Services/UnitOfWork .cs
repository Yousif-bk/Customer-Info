using AutoMapper;
using CustomerInfo.Data;
using CustomerInfo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ICustomerRepository _customerRepository;
        private IAddressRepository _addressRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAddressRepository AddressRepository => _addressRepository ??= new AddressRepository(_context);
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
