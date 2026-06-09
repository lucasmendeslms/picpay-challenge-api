using PicPayChallenge.Application.DTOs.Customer;
using FluentValidation;

namespace PicPayChallenge.Application.DTOs.Customer.Validators;

public class RegisterCustomerDtoValidator : AbstractValidator<RegisterCustomerDto>
{
   public RegisterCustomerDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .Length(11)
            .WithMessage("CPF must be exactly 11 characters.")
            .Matches(@"^\d{11}$")
            .WithMessage("CPF must contain only digits.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.");
    }
}