using EduMark.Application.Contracts;
using EduMark.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace EduMark.Api.Controllers;
[ApiController, Route("api/v1/courses")]
public sealed class CoursesController(ICourseService courses) : ControllerBase
{
    [HttpGet] public Task<IReadOnlyList<CourseResponse>> GetAll([FromQuery] bool publishedOnly = false, CancellationToken ct = default) => courses.GetAllAsync(publishedOnly, ct);
    [HttpGet("{id:guid}")] public async Task<ActionResult<CourseResponse>> GetById(Guid id, CancellationToken ct) { var c = await courses.GetByIdAsync(id, ct); return c is null ? NotFound() : Ok(c); }
    [HttpPost] public async Task<ActionResult<CourseResponse>> Create(CreateCourseRequest r, CancellationToken ct) { var c = await courses.CreateAsync(r, ct); return CreatedAtAction(nameof(GetById), new { c.Id }, c); }
    [HttpPut("{id:guid}")] public async Task<ActionResult<CourseResponse>> Update(Guid id, UpdateCourseRequest r, CancellationToken ct) { var c = await courses.UpdateAsync(id, r, ct); return c is null ? NotFound() : Ok(c); }
    [HttpDelete("{id:guid}")] public async Task<IActionResult> Delete(Guid id, CancellationToken ct) => await courses.DeleteAsync(id, ct) ? NoContent() : NotFound();
}
