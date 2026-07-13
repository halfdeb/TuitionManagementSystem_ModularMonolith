namespace Shared.DDD;

public abstract class AuditableEntity<TId> : AggregateRoot<TId>, ISoftDelete 
    where TId : notnull
{
    public DateTime CreatedAtUtc { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? LastModifiedAtUtc { get; private set; }
    public string? LastModifiedBy { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAtUtc { get; private set; }
    
    
    protected AuditableEntity() {}
    protected AuditableEntity(TId id) : base(id) { }

    public void MarkDeleted()
    {
        IsDeleted = true;
        DeletedAtUtc = DateTime.UtcNow;
    }
    
    //Called by AuditableEntityInterceptor on SaveChanges - do not call directly

    public void SetAudit(string? actor, bool isNew)
    {
        var now = DateTime.UtcNow;
        if (isNew)
        {
            CreatedAtUtc = now;
            CreatedBy = actor;
        }
        LastModifiedAtUtc = now;
        LastModifiedBy = actor;
    }
}