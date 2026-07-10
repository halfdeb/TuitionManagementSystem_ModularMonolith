namespace Shared.DDD;

public abstract record DomainEvent : IDomainEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime OccuredOnUtc { get; init; } = DateTime.UtcNow;
}