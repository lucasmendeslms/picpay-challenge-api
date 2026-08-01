namespace PicPayChallenge.Application.DTOs;

public record RegisterCustomerResponse(
    string Username,
    string Agency,
    string AccountNumber,
    int Digit,
    decimal Balance 
);