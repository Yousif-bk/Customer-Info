using CustomerInfo.Data;
using CustomerInfo.Utilities.Response;
using FluentValidation.Results;

namespace CustomerInfo.Helper.Validation
{
    public class ValidationHelper
    {
        public static BaseResponse GetValidationErrorResponse(ValidationResult validationResult)
        {
            var errors = validationResult.Errors
                .Select(error => new ValidationErrorCollection
                {
                    Name = error.PropertyName,
                    Description = error.ErrorMessage
                })
                .ToList();
            return new ValidationError
            {
                IsSuccess = false,
                StatusCode = 500,
                ResponseMessage = "Validation Error",
                ValidationErrorCollection = errors
            };
        }
    }
}
