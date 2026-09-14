using EduMark.Application.Contracts;
using EduMark.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace EduMark.Api.Controllers;
[ApiController, Route("api/v1/courses/{courseId:guid}/enrollments")]
public sealed class EnrollmentsController(IEnrollmentService enrollments) : ControllerBase
{
    [HttpGet] public Task<IReadOnlyList<EnrollmentResponse>> GetByCourse(Guid courseId, CancellationToken ct) => enrollments.GetByCourseAsync(courseId, ct);
    [HttpPost] public async Task<ActionResult<EnrollmentResponse>> Create(Guid courseId, CreateEnrollmentRequest r, CancellationToken ct) { var e = await enrollments.EnrollAsync(courseId, r, ct); return e is null ? NotFound(new { message = "Published course was not found." }) : StatusCode(StatusCodes.Status201Created, e); }
}
