using FluentValidation;
using PicPayChallenge.Domain.Constants;

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

        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(UserConstants.MAX_USERNAME_LENGTH);

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .Length(CustomerConstants.CPF_LENGTH)
            .WithMessage("CPF must be exactly 11 characters.")
            .Matches(@"^\d{11}$")
            .WithMessage("CPF must contain only digits.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(UserConstants.MIN_PASSWORD_LENGTH)
            .WithMessage("Password must be at least 8 characters long.");
    }
}