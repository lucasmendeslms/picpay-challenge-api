using PicPayChallenge.Domain.Enums;
using PicPayChallenge.Domain.ValueObjects;

namespace PicPayChallenge.Domain.Entities;

public class LedgerEntry
{
    public Guid Id { get; init; }
    public Guid LedgerId { get; init; }
    public Guid CorrelationId { get; init; }
    public decimal Amount { get; init; }
    public EntryType Type { get; init; }
    public string Description { get; init; } = string.Empty;
    public CounterpartyInfo Counterparty { get; init; } = null!;
    public DateTime CreatedAt { get; init; }

    private LedgerEntry() { }

    internal LedgerEntry(
        Guid ledgerId,
        Guid correlationId,
        decimal amount,
        EntryType type,
        string description,
        CounterpartyInfo counterparty
    )
    {
        Id = Guid.NewGuid();
        LedgerId = ledgerId;
        CorrelationId = correlationId;
        Amount = amount;
        Type = type;
        Description = description;
        Counterparty = counterparty ?? throw new ArgumentNullException(nameof(counterparty));
        CreatedAt = DateTime.UtcNow;
    }
}