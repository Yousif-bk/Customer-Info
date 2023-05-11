using CustomerInfo.Contracts;
using CustomerInfo.Dtos;
using CustomerInfo.Services;
using CustomerInfo.Utilities.Response;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInfo.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }

        [HttpGet(ApiRoutes.Address.GetAddresses)]
        public async Task<IActionResult> GetAllAddressesAsync()
        {
            BaseResponse response = await _addressServices.GetAllAddressesAsync();
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Address.CreateAddress)]
        public async Task<IActionResult> CreateAddressAsync(Guid customerId, CreateAddressDto addressDto)
        {
            BaseResponse response = await _addressServices.CreateAddressAsync(customerId, addressDto);
            return Ok(response);
        }

        [HttpDelete(ApiRoutes.Address.DeleteAddress)]
        public async Task<IActionResult> DeleteAddressAsync(Guid customerId, Guid addressId)
        {
            BaseResponse response = await _addressServices.DeleteAddress(customerId, addressId);
            return Ok(response);
        }
    }
}
