using Shared.DDD;

namespace Students.Students.Models;

public enum StudentStatus {Active, Inactive, OnHold, Graduated, Dropped}

public sealed class Student : AuditableEntity<Guid>
{
    public string FullName { get; private set; } = default!;
    public string? GuardianName { get; private set; }
    public string? GuardianPhone { get; private set; }
    public string? AcademicClass { get; private set; } = default!;
    public Guid BranchId { get; private set; }
    public StudentStatus Status { get; private set; }
    private readonly List<Guid> _enrolledBatchIds = new();
    public IReadOnlyCollection<Guid> EnrolledBatchIds => _enrolledBatchIds.AsReadOnly();
    
    private Student() {}

    public static Student Create(string fullName, string academicClass, Guid branchId,
        string? guardianName, string? guardianPhone)
    {
        var student = new Student
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            AcademicClass = academicClass,
            BranchId = branchId,
            GuardianName = guardianName,
            GuardianPhone = guardianPhone,
            Status = StudentStatus.Active
        };
        
        student.Raise(new StudentCreatedDomainEvent(student.Id, student.BranchId));
        return student;
    }
    
    //BR-ENR-02 (capacity) is enforced by the Batch aggregate; this just records the
    // relationship once EnrollStudentCommandHandler has validated it against Batch.
    
    // TO DO
    
    public void Promote(string newAcademicClass) => AcademicClass = newAcademicClass;
    public void Drop() => Status = StudentStatus.Dropped;

}