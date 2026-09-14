using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen(); builder.Services.AddSingleton<NotificationStore>();
var app = builder.Build();
app.UseSwagger(); app.UseSwaggerUI();
app.MapGet("/health", () => Results.Ok(new { status = "healthy", service = "edumark-notification-service", utc = DateTime.UtcNow }));
app.MapPost("/api/v1/notifications/enrollment", (EnrollmentNotificationRequest request, NotificationStore store) => { var results = new List<ValidationResult>(); if (!Validator.TryValidateObject(request, new ValidationContext(request), results, true)) return Results.ValidationProblem(results.ToDictionary(x => x.MemberNames.FirstOrDefault() ?? "request", x => new[] { x.ErrorMessage ?? "Invalid value" })); var notification = new Notification(Guid.NewGuid(), request.StudentEmail.Trim().ToLowerInvariant(), request.CourseTitle.Trim(), request.EnrolledAtUtc, DateTime.UtcNow); store.Items.Enqueue(notification); return Results.Created($"/api/v1/notifications/{notification.Id}", notification); });
app.MapGet("/api/v1/notifications", (NotificationStore store) => Results.Ok(store.Items.ToArray()));
app.Run();
public sealed class NotificationStore { public ConcurrentQueue<Notification> Items { get; } = new(); }
public sealed record Notification(Guid Id, string StudentEmail, string CourseTitle, DateTime EnrolledAtUtc, DateTime ReceivedAtUtc);
public sealed class EnrollmentNotificationRequest { [Required, EmailAddress] public string StudentEmail { get; init; } = string.Empty; [Required, StringLength(160)] public string CourseTitle { get; init; } = string.Empty; public DateTime EnrolledAtUtc { get; init; } }
