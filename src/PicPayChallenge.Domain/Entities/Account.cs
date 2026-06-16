namespace PicPayChallenge.Domain.Entities;

public class Account
{
    public Guid Id { get; init; }
    public Guid UserId { get; private set; }
    public string Agency { get; private set; } = null!;
    public int AccountNumber { get; private set; }
    public int Digit { get; private set; }
    public decimal Balance { get; private set; }

    public Account(Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Balance = 0.00m;
    }

}