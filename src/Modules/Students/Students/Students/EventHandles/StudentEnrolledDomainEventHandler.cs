using MediatR;
using Microsoft.Extensions.Logging;
using Students.Students.Models;

namespace Students.Students.EventHandles;

public sealed class StudentEnrolledDomainEventHandler : INotificationHandler<StudentEnrolledDomainEvent>
{
    private readonly ILogger<StudentEnrolledDomainEventHandler> _logger;

    public StudentEnrolledDomainEventHandler(ILogger<StudentEnrolledDomainEventHandler> logger) => _logger = logger;

    public Task Handle(StudentEnrolledDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Student {StudentId} enrolled in batch {BatchId}",
            notification.StudentId, notification.BatchId);
        
        // The Outbox interceptor (Shared.Messaging) also maps this to a
        // StudentEnrolledIntegrationEvent for the Payments module to consume asynchronously.
        return Task.CompletedTask;
    }
}