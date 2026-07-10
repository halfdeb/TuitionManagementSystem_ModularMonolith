using MediatR;

namespace Shared.DDD;

public interface IDomainEvent : INotification
{
    Guid EventId { get; }
    DateTime OccuredOnUtc { get; }
}