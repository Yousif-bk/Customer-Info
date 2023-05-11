namespace CustomerInfo.Utilities.Response
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
       
        public BaseResponse()
        {
        }
        public BaseResponse(bool success, int statusCode, string responseMessage)
        {
            IsSuccess = success;
            StatusCode = statusCode;
            ResponseMessage = responseMessage;
        }
    }
}
