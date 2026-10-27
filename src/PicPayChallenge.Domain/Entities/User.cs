using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Domain.Entities;

public abstract class User
{
    public const int MaxUsernameLength = 200;
    public const int MaxPasswordHashLength = 200;
    public const int MaxPasswordSaltLength = 200;
    public const int MaxEmailLength = 200;
    public const int MaxCepLength = 200;
    public const int MinPasswordLength = 8;

    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required Cep Cep { get; set; }
    
    public byte[] PasswordHash { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;

    public Account Account { get; private set; } = null!;

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new NullReferenceException($"{nameof(password)} cannot be null or empty");
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

        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        return computedHash.SequenceEqual(PasswordHash);
    }
}