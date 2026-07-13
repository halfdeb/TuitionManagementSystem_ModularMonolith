using Shared.Exception;

namespace Students.Students.Exceptions;

public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException(Guid studentId) : base(nameof(Models.Student), studentId) {}
}