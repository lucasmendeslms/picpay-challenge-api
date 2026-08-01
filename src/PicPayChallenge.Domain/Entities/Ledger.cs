using PicPayChallenge.Domain.Enums;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Domain.Entities;

public class Ledger
{
    private readonly List<LedgerEntry> _entries = [];

    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public DateTime CreatedAt { get; init; }
    public IReadOnlyCollection<LedgerEntry> Entries => _entries.AsReadOnly();

    private Ledger() { }

    public Ledger(Guid accountId)
    {
        Id = Guid.NewGuid();
        AccountId = accountId;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddEntry(
        Guid correlationId,
        decimal amount,
        EntryType operationType,
        string description,
        CounterpartyInfo counterparty
    )
    {
        _entries.Add(new LedgerEntry(
            Id, 
            correlationId,
            amount,
            operationType,
            description,
            counterparty
        ));
    }

    public bool IsBalanced()
    {
        var debits = _entries.Where(e => e.Type == EntryType.Debit).Sum(e => e.Amount);
        var credits = _entries.Where(e => e.Type == EntryType.Credit).Sum(e => e.Amount);
        return debits == credits;
    }
}