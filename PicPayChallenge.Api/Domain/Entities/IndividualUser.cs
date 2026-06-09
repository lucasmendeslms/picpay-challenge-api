namespace PicPayChallenge.Api.Model.Entities;

public class IndividualUser : User
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Cpf { get; init; }
}