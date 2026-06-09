using PicPayChallenge.Domain.Entities;

namespace PicPayChallenge.Application.DTOs.Customer;

public class RegisterCustomerDto(string firstName, string lastName, string cpf, string email, string password)
{
    public string FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public string Cpf { get; set; } = cpf;
    
    public string Email { get; set; } = email;
    
    public string Password { get; set; } = password;
}