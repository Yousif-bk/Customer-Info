using CustomerInfo.Dtos;

namespace CustomerInfo.Utilities.Response
{
    public static class Responses
    {

        public static BaseResponse AddressNotFound(Guid addressId)
        {
            return new BaseResponse
            {
                IsSuccess = false,
                StatusCode = 404,
                ResponseMessage = $"No address was found with ID:{addressId}"
            };
        }

        public static BaseResponse AddressDoesNotBelongToCustomer(Guid addressId, Guid customerId)
        {
            return new BaseResponse
            {
                IsSuccess = false,
                StatusCode = 400,
                ResponseMessage = $"Address with ID:{addressId} does not belong to customer with ID:{customerId}"
            };
        }
        public static DataResponse<IEnumerable<AddressDto>> AddressResponse(IEnumerable<AddressDto> data)
        {
            return new DataResponse<IEnumerable<AddressDto>>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Request Completed Successfully",
            };
        }
        public static BaseResponse SuccessResponse()
        {
            return new BaseResponse
            {
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Request Completed successfully"
            };
        }

        public static BaseResponse CustomerNotFound(Guid customerId)
        {
            return new BaseResponse
            {
                IsSuccess = false,
                StatusCode = 404,
                ResponseMessage = $"No customer was found with ID:{customerId}"
            };
        }
        public static DataResponse<IEnumerable<CustomerDto>> CustomersResponse(IEnumerable<CustomerDto> data)
        {
            return new DataResponse<IEnumerable<CustomerDto>>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Request Completed Successfully",
            };
        }
        public static DataResponse<CustomerDto> CustomerResponse(CustomerDto data)
        {
            return new DataResponse<CustomerDto>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Request Completed Successfully",
            };
        }
        public static DataResponse<IEnumerable<CustomerDto>> CustomersByCityResponse(IEnumerable<CustomerDto> data, string cityName)
        {
            return new DataResponse<IEnumerable<CustomerDto>>
            {
                Data = data,
                IsSuccess = false,
                StatusCode = 404,
                ResponseMessage = $"No customers were found in the city of {cityName}"
            };
        }
        public static DataResponse<CustomerDto> CustomerNotFountResponse(CustomerDto data, Guid id)
        {
            return new DataResponse<CustomerDto>
            {
                Data = data,
                IsSuccess = false,
                StatusCode = 404,
                ResponseMessage = $"No customer was found with ID:{id}"
            };
        }
    }
}
