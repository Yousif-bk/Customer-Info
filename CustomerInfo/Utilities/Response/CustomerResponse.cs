using CustomerInfo.Dtos;
using CustomerInfo.Models;

namespace CustomerInfo.Utilities.Response
{
    public class DataResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
