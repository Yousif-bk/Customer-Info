using CustomerInfo.Contracts;
using CustomerInfo.Dtos;
using CustomerInfo.Services;
using CustomerInfo.Utilities.Response;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInfo.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet(ApiRoutes.Customer.GetCustomers)]
        public async Task<IActionResult> GetCustomersAsync()
        {
            BaseResponse response = await _customerServices.GetCustomersAsync();
            return Ok(response);
        }

        [HttpGet(ApiRoutes.Customer.GetCustomer)]
        public async Task<IActionResult> GetCustomerAsync(Guid id)
        {
            BaseResponse response = await _customerServices.GetCustomerAsync(id);
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Customer.CreateCustomer)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDto)
        {
            BaseResponse response = await _customerServices.CreateCustomerAsync(customerDto);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.Customer.GetCustomersByCity)]
        public async Task<IActionResult> GetCustomersByCity(string cityName)
        {
            BaseResponse response = await _customerServices.GetCustomersByCityAsync(cityName);
            return Ok(response);
        }
    }
}
