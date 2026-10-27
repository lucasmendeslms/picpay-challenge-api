using PicPayChallenge.Domain.Enums;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Domain.Entities;

public class Account
{
    public const string AgencyNumber = "001";
    public const string BalanceColumnType = "decimal(18,2)";
    public const decimal DefaultInitialBalance = 0.00m;
    public const int MaxAgencyDigitsLength = 4;


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
        AccountNumber = AccountNumber.Generate();
        Agency = AgencyNumber;
        Balance = DefaultInitialBalance;
        Status = StatusAccount.Pending;
    }
}