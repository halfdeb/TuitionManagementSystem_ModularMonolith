namespace Shared.DDD;

public interface ISoftDelete
{
    bool IsDeleted { get; }
    DateTime? DeletedAtUtc { get; }
    void MarkDelete();
}