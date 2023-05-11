namespace CustomerInfo.Utilities.Response
{
    public class ValidationError : BaseResponse
    {
        public List<ValidationErrorCollection> ValidationErrorCollection { get; set; }
    }

    public class ValidationErrorCollection
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
