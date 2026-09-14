namespace EduMark.Application.Contracts;
public sealed record EnrollmentNotification(string StudentEmail, string CourseTitle, DateTime EnrolledAtUtc);
