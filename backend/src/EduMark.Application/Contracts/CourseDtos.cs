using System.ComponentModel.DataAnnotations;
namespace EduMark.Application.Contracts;
public sealed record CourseResponse(Guid Id, string Title, string Slug, string Description, decimal Price, bool IsPublished, DateTime CreatedAtUtc);
public class CreateCourseRequest { [Required, StringLength(160, MinimumLength = 3)] public string Title { get; init; } = string.Empty; [Required, StringLength(2000, MinimumLength = 10)] public string Description { get; init; } = string.Empty; [Range(0, 100_000)] public decimal Price { get; init; } public bool IsPublished { get; init; } = true; }
public sealed class UpdateCourseRequest : CreateCourseRequest { }
