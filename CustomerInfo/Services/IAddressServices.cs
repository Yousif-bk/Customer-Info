using CustomerInfo.Dtos;
using CustomerInfo.Models;
using CustomerInfo.Utilities.Response;

namespace CustomerInfo.Services
{
    public interface IAddressServices
    {
        Task<BaseResponse> CreateAddressAsync(Guid id, CreateAddressDto addressDto);
        Task<BaseResponse> DeleteAddress(Guid addressId, Guid customerId);
        Task<Address> GetAddressAsync(Guid id);
        Task<DataResponse<IEnumerable<AddressDto>>> GetAllAddressesAsync();
    }
}
