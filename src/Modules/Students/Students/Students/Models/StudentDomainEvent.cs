using Shared.DDD;

namespace Students.Students.Models;

public sealed record StudentCreatedDomainEvent(Guid studentId, Guid BranchId) : DomainEvent;

// Also mapped to a cross-module IntegrationEvent (StudentEnrolledIntegrationEvent) by
// the Outbox interceptor so the Payments module can generate the student's first invoice 

public sealed record StudentEnrolledDomainEvent(Guid StudentId, Guid BatchId) : DomainEvent;