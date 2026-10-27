using FluentValidation;
using PicPayChallenge.Domain.Entities;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Application.DTOs;

public class RegisterCustomerRequestValidator : AbstractValidator<RegisterCustomerRequest>
{
    public RegisterCustomerRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(User.MaxUsernameLength);

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .WithMessage("CPF is required.")
            .Must(Cpf.IsValid)
            .WithMessage("CPF must contain only digits.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(User.MinPasswordLength)
            .WithMessage("Password must be at least 8 characters long.");
    }
}