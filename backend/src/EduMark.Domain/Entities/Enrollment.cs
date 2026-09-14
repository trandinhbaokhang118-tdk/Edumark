namespace EduMark.Domain.Entities;
public sealed class Enrollment { public Guid Id { get; set; } = Guid.NewGuid(); public Guid CourseId { get; set; } public string StudentEmail { get; set; } = string.Empty; public DateTime EnrolledAtUtc { get; set; } = DateTime.UtcNow; public Course Course { get; set; } = null!; }
