using AutoMapper;
using CustomerInfo.Dtos;
using CustomerInfo.Helper.Validation;
using CustomerInfo.Models;
using CustomerInfo.Utilities.Response;
using FluentValidation;

namespace CustomerInfo.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateCustomerDto> _validator;

        public CustomerServices(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateCustomerDto> validator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<DataResponse<IEnumerable<CustomerDto>>> GetCustomersAsync()
        {
            IEnumerable<Customer> customers = await _unitOfWork.CustomerRepository.GetAllCustomersAsync();
            IEnumerable<CustomerDto> data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return Responses.CustomersResponse(data);
        }
        public async Task<DataResponse<CustomerDto>> GetCustomerAsync(Guid id)
        {
            Customer customer = await _unitOfWork.CustomerRepository.GetCustomerAsync(id);
            CustomerDto data = _mapper.Map<CustomerDto>(customer);


            if (data == null)
                return Responses.CustomerNotFountResponse(data, id);


            return Responses.CustomerResponse(data);
        }

        public async Task<BaseResponse> CreateCustomerAsync(CreateCustomerDto customerDto)
        {
            var validationResult = _validator.Validate(customerDto);


            if (!validationResult.IsValid)
                return ValidationHelper.GetValidationErrorResponse(validationResult);


            Customer customer = _mapper.Map<Customer>(customerDto);


            await _unitOfWork.CustomerRepository.CreateCustomerAsync(customer);
            await _unitOfWork.SaveAsync();


            return Responses.SuccessResponse();
        }

        public async Task<DataResponse<IEnumerable<CustomerDto>>> GetCustomersByCityAsync(string cityName)
        {
            IEnumerable<Customer> customers = await _unitOfWork.CustomerRepository.GetCustomersByCityAsync(cityName);
            IEnumerable<CustomerDto> data = _mapper.Map<IEnumerable<CustomerDto>>(customers);


            if (data == null || !data.Any())
                return Responses.CustomersByCityResponse(data, cityName);

            return Responses.CustomersResponse(data);
        }
    }
}
