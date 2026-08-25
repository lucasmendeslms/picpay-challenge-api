using PicPayChallenge.Domain.Enums;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Domain.Entities;

public class Account
{
    private const string AgencyNumber = "001";
    private const decimal InitialBalance = 0.00m;

    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public AccountNumber AccountNumber { get; private set; }
    public string Agency { get; private set; }
    public decimal Balance { get; private set; }
    public StatusAccount Status { get; private set; }

    public Account(Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        AccountNumber = new AccountNumber();
        Agency = AgencyNumber;
        Balance = InitialBalance;
        Status = StatusAccount.Pending;
    }
}