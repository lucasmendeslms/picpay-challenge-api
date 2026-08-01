namespace PicPayChallenge.Domain.ValueObjects;

public record CounterpartyInfo(
    string Name,
    string Document,
    string BankCode,
    string AccountNumber,
    string Agency
);