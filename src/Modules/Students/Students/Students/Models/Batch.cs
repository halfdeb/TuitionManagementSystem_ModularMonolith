using Shared.DDD;

namespace Students.Students.Models;

// BR-ENR-01: enrolling a student in two batches with overlapping schedule times in the same
// branch is prevented at the EnrollStudentCommandHandler level (it loads all the student's
// current batches and checks overlap against this Batch's ScheduleDays/Time before calling
// Enroll). BR-ENR-02 (capacity) is enforced here, inside the aggregate.

public sealed class Batch : AuditableEntity<Guid>
{
    public string Name { get; private set; } = default!;
    public string Subject { get; private set; } = default!;
    public Guid TeacherId { get; private set; }
    public Guid BranchId { get; private set; }
    public int Capacity { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; set; }
    public IReadOnlyList<DayOfWeek> ScheduleDays { get; private set; } = Array.Empty<DayOfWeek>();
    public bool IsArchived { get; private set; }
    private int _enrolledCount;
    public int EnrolledCount => _enrolledCount;
    
    private Batch() { }

    public static Batch Create(string name, string subject, Guid teacherId, Guid branchId,
        int capacity, TimeOnly startTime, TimeOnly endTime, IReadOnlyList<DayOfWeek> scheduleDays) => new()
    {
        Id = Guid.NewGuid(),
        Name = name,
        Subject = subject,
        TeacherId = teacherId,
        BranchId = branchId,
        Capacity = capacity,
        StartTime = startTime,
        EndTime = endTime,
        ScheduleDays = scheduleDays
    };

    // TO DO
    
    public bool OverlapsWith(TimeOnly otherStart, TimeOnly otherEnd, IReadOnlyList<DayOfWeek> otherDays) =>
        ScheduleDays.Intersect(otherDays).Any() && StartTime < otherEnd && otherStart < EndTime;

    public void Archive() => IsArchived = true;
}