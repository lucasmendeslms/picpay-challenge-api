using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Domain.Entities;

public class Customer : User
{
    public const int MaxFirstNameLength = 200;
    public const int MaxLastNameLength = 200;

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Cpf Cpf { get; init; }
}