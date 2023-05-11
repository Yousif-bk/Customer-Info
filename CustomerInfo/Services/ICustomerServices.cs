using CustomerInfo.Dtos;
using CustomerInfo.Models;
using CustomerInfo.Utilities.Response;

namespace CustomerInfo.Services
{
    public interface ICustomerServices
    {
        Task<DataResponse<IEnumerable<CustomerDto>>> GetCustomersAsync();
        Task<DataResponse<CustomerDto>> GetCustomerAsync(Guid id);
        Task<BaseResponse> CreateCustomerAsync(CreateCustomerDto customerDto);
        Task<DataResponse<IEnumerable<CustomerDto>>> GetCustomersByCityAsync(string cityName);
    }
}
