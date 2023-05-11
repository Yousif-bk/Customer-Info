using CustomerInfo.Dtos;
using FluentValidation;

namespace CustomerInfo.Helper.Validation
{
    public class CustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot be longer than 50 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches("^\\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("Phone number must be in international format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not in a valid format.");
        }
    }
}
