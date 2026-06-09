using PicPayChallenge.Domain.Exceptions;

namespace PicPayChallenge.Domain.Entities;

public abstract class User
{
    public int Id { get; protected set; }
    public Guid PublicId { get; init; } = Guid.NewGuid();
    public required string Email { get; set; }
    public required string Cep { get; set; }
    
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    public decimal Balance { get; protected set; } = 0.00m;

    protected void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new DomainException($"{nameof(password)} cannot be null or empty");
        }

        using var hmac = new System.Security.Cryptography.HMACSHA512();
        PasswordSalt = hmac.Key;
        PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        using var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt);

        var computedHash = hmac.ComputeHash(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));

        return computedHash.SequenceEqual(PasswordHash);
    }
}