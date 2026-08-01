namespace PicPayChallenge.Application.DTOs;

public record RegisterCustomerRequest(
    string FirstName,
    string LastName,
    string Username,
    string Cpf,
    string Email,
    string Cep,
    string Password
);