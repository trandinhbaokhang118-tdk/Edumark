using System.ComponentModel.DataAnnotations;
namespace EduMark.Application.Contracts;
public sealed class CreateEnrollmentRequest { [Required, EmailAddress, StringLength(254)] public string StudentEmail { get; init; } = string.Empty; }
public sealed record EnrollmentResponse(Guid Id, Guid CourseId, string CourseTitle, string StudentEmail, DateTime EnrolledAtUtc);
