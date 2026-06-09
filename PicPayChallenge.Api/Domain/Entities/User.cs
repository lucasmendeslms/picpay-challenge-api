namespace PicPayChallenge.Api.Model.Entities;

public abstract class User
{
    public int Id { get; private set; }
    public required string Email { get; set; }
    public required string Cep { get; set; }
    
    
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
}