using AutoMapper;
using CustomerInfo.Dtos;
using CustomerInfo.Models;
using CustomerInfo.Utilities.Response;

namespace CustomerInfo.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddressServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DataResponse<IEnumerable<AddressDto>>> GetAllAddressesAsync()
        {
            IEnumerable<Address> address = await _unitOfWork.AddressRepository.GetAllAddressesAsync();
            IEnumerable<AddressDto> data = _mapper.Map<IEnumerable<AddressDto>>(address);
            return Responses.AddressResponse(data);
        }
        public async Task<Address> GetAddressAsync(Guid id)
        {
            Address address = await _unitOfWork.AddressRepository.GetAddressAsync(id);
            return address;
        }
        public async Task<BaseResponse> CreateAddressAsync(Guid customerId, CreateAddressDto addressDto)
        {
            Customer customer = await _unitOfWork.CustomerRepository.GetCustomerAsync(customerId);
            if (customer == null)
                return Responses.CustomerNotFound(customerId);


            Address address = _mapper.Map<Address>(addressDto);
            address.CustomerId = customerId;
            await _unitOfWork.AddressRepository.CreateAddressAsync(address);
            await _unitOfWork.SaveAsync();


            return Responses.SuccessResponse();
        }

        public async Task<BaseResponse> DeleteAddress(Guid customerId, Guid addressId)
        {
            Customer customer = await _unitOfWork.CustomerRepository.GetCustomerAsync(customerId);
            if (customer == null)
                return Responses.CustomerNotFound(customerId);


            Address address = await GetAddressAsync(addressId);
            if (address == null)
                return Responses.AddressNotFound(addressId);


            if (address.CustomerId != customerId)
                return Responses.AddressDoesNotBelongToCustomer(addressId, customerId);


            await _unitOfWork.AddressRepository.DeleteAddress(address);
            await _unitOfWork.SaveAsync();


            return Responses.SuccessResponse();
        }
    }
}
