using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{

    public RegisterRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email)
               .NotEmpty().WithMessage("Email is required")
               .EmailAddress().WithMessage("Invalid email address format");


        //Password
        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required")
            .Length(4, 10).WithMessage("Password must be between 4 and 10 chars");

        RuleFor(temp => temp.PersonName)
        .NotEmpty().WithMessage("Person name is required")
        .Length(4, 10).WithMessage("Person name must be between 4 and 10 chars");


        RuleFor(temp => temp.Gender)
        .IsInEnum().WithMessage("gender is invalid");
        
    }

}
    

