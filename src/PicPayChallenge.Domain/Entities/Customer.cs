namespace PicPayChallenge.Domain.Entities;

public class Customer : User
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Cpf { get; init; }
}