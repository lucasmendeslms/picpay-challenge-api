using PicPayChallenge.Domain.Enums;

namespace PicPayChallenge.Domain.Entities;

public class Account(Guid userId)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; init; } = userId;
    public string Agency { get; private set; } = null!;
    public int AccountNumber { get; private set; }
    public int Digit { get; private set; }
    public decimal Balance { get; private set; } = 0.00m;
    public StatusAccount Status { get; private set; } = StatusAccount.Active;
}